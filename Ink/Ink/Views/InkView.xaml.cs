namespace Ink
{
    using Views.Base;
    using Windows.UI.Input.Inking;

    public sealed partial class InkView : PageBase
    {
        public InkView()
        {
            this.InitializeComponent();

            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;

            Ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
            Ink.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }
    }
}
