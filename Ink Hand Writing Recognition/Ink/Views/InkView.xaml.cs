namespace Ink
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using ViewModels;
    using Views.Base;
    using Windows.UI.Input.Inking;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class InkView : PageBase
    {
        private InkViewModel _vm;

        public InkView()
        {
            this.InitializeComponent();

            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;

            Ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
            Ink.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse 
                | Windows.UI.Core.CoreInputDeviceTypes.Pen
                | Windows.UI.Core.CoreInputDeviceTypes.Touch;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = DataContext as InkViewModel;

            if (_vm != null)
                _vm.Recognize += Recognize;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _vm = DataContext as InkViewModel;

            if (_vm != null)
                _vm.Recognize -= Recognize;

            base.OnNavigatedFrom(e);
        }

        private async void Recognize(object sender, EventArgs e)
        {
            if (Ink != null)
            {
                string str = string.Empty;
                IReadOnlyList<InkStroke> currentStrokes = Ink.InkPresenter.StrokeContainer.GetStrokes();
                if (currentStrokes.Count > 0)
                {
                    try
                    {
                        var inkRecognizerContainer = new InkRecognizerContainer();
                        var recognitionResults = await inkRecognizerContainer.RecognizeAsync(Ink.InkPresenter.StrokeContainer, InkRecognitionTarget.All);

                        if (recognitionResults.Count > 0)
                            foreach (var r in recognitionResults)
                                str += r.GetTextCandidates()[0];
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                if (_vm != null)
                    _vm.RecognizeResult(str);
            }
        }
    }
}
 