namespace Print.Services.Print
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Windows.ApplicationModel.Core;
    using Windows.Graphics.Printing;
    using Windows.Graphics.Printing.OptionDetails;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Printing;

    public class PrintService : IPrintService
    {
        #region Fields

        protected PrintManager Printmgr;
        protected PrintDocument PrintDoc;
        protected PrintTask Task;
        protected UIElement PrintContent;

        internal string PrintTitle;

        #endregion

        #region Methods

        public virtual void RegisterForPrinting()
        {
            PrintDoc = new PrintDocument();
            PrintDoc.Paginate += CreatePrintPreviewPages;
            PrintDoc.GetPreviewPage += GetPrintPreviewPage;
            PrintDoc.AddPages += AddPrintPages;

            Printmgr = PrintManager.GetForCurrentView();

            Printmgr.PrintTaskRequested += PrintTaskRequested;
        }

        public virtual void UnregisterForPrinting()
        {
            if (PrintDoc == null)
            {
                return;
            }

            PrintDoc.Paginate -= CreatePrintPreviewPages;
            PrintDoc.GetPreviewPage -= GetPrintPreviewPage;
            PrintDoc.AddPages -= AddPrintPages;

            Printmgr.PrintTaskRequested -= PrintTaskRequested;
        }

        public async void ShowPrintUiAsync(string title)
        {
            try
            {
                PrintTitle = title;

                await PrintManager.ShowPrintUIAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error printing: " + e.Message + ", hr=" + e.HResult);
            }
        }

        public virtual void SetPrintContent(UIElement content)
        {
            if (content == null)
                return;

            PrintContent = content;
        }

        protected virtual void PrintTaskRequested(PrintManager sender,
            PrintTaskRequestedEventArgs e)
        {
            Task = e.Request.CreatePrintTask(PrintTitle, async sourceRequested =>
            {
                PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(Task.Options);

                printDetailedOptions.DisplayedOptions.Clear();
                printDetailedOptions.DisplayedOptions.Add(StandardPrintTaskOptions.Copies);

                Task.Options.Orientation = PrintOrientation.Portrait;

                Task.Completed += async (s, args) =>
                {
                    if (args.Completion == PrintTaskCompletion.Failed)
                    {
                        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            Debug.WriteLine("Failed to print.");
                        });
                    }
                };

                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    sourceRequested.SetSource(PrintDoc?.DocumentSource);
                });
            });
        }

        protected virtual void CreatePrintPreviewPages(object sender, PaginateEventArgs e)
        {
            PrintDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
        }

        protected virtual void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            PrintDocument printDoc = (PrintDocument)sender;
            printDoc.SetPreviewPage(e.PageNumber, PrintContent);
        }

        protected virtual void AddPrintPages(object sender, AddPagesEventArgs e)
        {
            PrintDoc.AddPage(PrintContent);

            PrintDoc.AddPagesComplete();
        }

        #endregion
    }
}