namespace Ink.Behaviors
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Input;
    using Windows.Foundation;
    using Windows.UI.Input.Inking;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public static class InkBehavior
    {
        public static SolidColorBrush GetPenColor(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(PenColorProperty);
        }

        public static void SetPenColor(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(PenColorProperty, value);
        }

        public static readonly DependencyProperty PenColorProperty =
            DependencyProperty.RegisterAttached("PenColor", typeof(SolidColorBrush),
            typeof(InkBehavior), new PropertyMetadata(null,
            PenColor));

        private static void PenColor(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            InkCanvas ink = d as InkCanvas;
            if (ink == null) return;

            InkDrawingAttributes drawingAttributes = ink.InkPresenter.CopyDefaultDrawingAttributes();
            var brush = e.NewValue as SolidColorBrush;
            drawingAttributes.Color = brush.Color;

            ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }

        public static int GetPenSize(DependencyObject obj)
        {
            return (int)obj.GetValue(PenSizeProperty);
        }

        public static void SetPenSize(DependencyObject obj, int value)
        {
            obj.SetValue(PenSizeProperty, value);
        }

        public static readonly DependencyProperty PenSizeProperty =
            DependencyProperty.RegisterAttached("PenSize", typeof(int),
            typeof(InkBehavior), new PropertyMetadata(null,
            PenSize));

        private static void PenSize(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            InkCanvas ink = d as InkCanvas;
            if (ink == null) return;

            InkDrawingAttributes drawingAttributes = ink.InkPresenter.CopyDefaultDrawingAttributes();
            var size = Convert.ToInt32(e.NewValue);
            drawingAttributes.Size = new Size(size, size);

            ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }

        public static PenType GetPenType(DependencyObject obj)
        {
            return (PenType)obj.GetValue(PenTypeProperty);
        }

        public static void SetPenType(DependencyObject obj, PenType value)
        {
            obj.SetValue(PenTypeProperty, value);
        }

        public static readonly DependencyProperty PenTypeProperty =
            DependencyProperty.RegisterAttached("PenType", typeof(PenType),
            typeof(InkBehavior), new PropertyMetadata(null,
            PenTypeChanged));

        private static void PenTypeChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            InkCanvas ink = d as InkCanvas;
            if (ink == null) return;

            InkDrawingAttributes drawingAttributes = ink.InkPresenter.CopyDefaultDrawingAttributes();

            var penType = e.NewValue as PenType?;

            if (penType == null)
                return;

            switch (penType)
            {
                case PenType.Ballpoint:
                    drawingAttributes.PenTip = PenTipShape.Circle;
                    drawingAttributes.DrawAsHighlighter = false;
                    drawingAttributes.PenTipTransform = System.Numerics.Matrix3x2.Identity;
                    break;
                case PenType.Calligraphy:
                    drawingAttributes.PenTip = PenTipShape.Rectangle;
                    drawingAttributes.DrawAsHighlighter = true;
                    drawingAttributes.PenTipTransform = System.Numerics.Matrix3x2.Identity;
                    break;
                case PenType.Highlighter:
                    drawingAttributes.PenTip = PenTipShape.Rectangle;
                    drawingAttributes.DrawAsHighlighter = false;

                    // Set a 45 degree rotation on the pen tip
                    double radians = 45.0 * Math.PI / 180;
                    drawingAttributes.PenTipTransform = System.Numerics.Matrix3x2.CreateRotation((float)radians);
                    break;
            }

            ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }

        public static bool GetIsClear(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsClearProperty);
        }

        public static void SetIsClear(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClearProperty, value);
        }

        public static readonly DependencyProperty IsClearProperty =
            DependencyProperty.RegisterAttached("IsClear", typeof(bool),
            typeof(InkBehavior), new PropertyMetadata(null,
            IsClearChanged));

        private static void IsClearChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            InkCanvas ink = d as InkCanvas;
            if (ink == null) return;

            var isClear = e.NewValue as bool?;

            if (isClear.HasValue && isClear.Value)
            {
                ink.InkPresenter.StrokeContainer.Clear();
                SetIsClear(ink, false);
            }
        }
    }
}