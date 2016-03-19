namespace Print.Services.Print
{
    using Windows.UI.Xaml;

    public interface IPrintService
    {
        void RegisterForPrinting();

        void SetPrintContent(UIElement content);

        void ShowPrintUiAsync(string title);

        void UnregisterForPrinting();
    }
}