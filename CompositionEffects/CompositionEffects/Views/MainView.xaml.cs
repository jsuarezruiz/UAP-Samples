namespace CompositionEffects
{
    using Microsoft.Graphics.Canvas;
    using Microsoft.Graphics.Canvas.Effects;
    using System;
    using System.Numerics;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Composition;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Hosting;

    public sealed partial class MainView : IFrameworkView
    {
        private ICoreWindow _window;
        private ContainerVisual _rootVisual;
        private Compositor _compositor;
        private CompositionTarget _target;

        public object CanvvasComposite { get; private set; }

        public MainView()
        {
            this.InitializeComponent();

            CreateCircleMaskToImage(new Uri("ms-appx:///Assets/Alf.png"), new Vector3(0), new Vector2(250));
        }

        private void InitializeCompositor()
        {
            _compositor = new Compositor();

            _target 
        }

        private void BuildVisualTree()
        {
            // Create Solid Color Background
            SolidColorVisual background = _compositor.CreateSolidColorVisual();
        }

        private void CreateCircleMaskToImage(Uri imageUri, Vector3 offset, Vector2 size)
        {
            //CompositionImage profileImage = _compositor.DefaultGraphicsDevice.CreateImageFromUri(imageUri);

            //CompositionImage maskImage = _compositor.DefaultGraphicsDevice.CreateImageFromUri(
            //    new Uri("ms-appx:///Assets/Mask.png"));

            //CompositeEffect maskComposite = new CompositeEffect();
            //maskComposite.Sources.Add(new CompositionEffectSourceParameter("image"));
            //maskComposite.Sources.Add(new CompositionEffectSourceParameter("maskImage"));
            //maskComposite.Mode = CanvasComposite.DestinationIn;
            //maskComposite.Name = "Mask";

            //CompositionEffectFactory effectFactory = _compositor.CreateEffectFactory(maskComposite);

            //CompositionEffect maskEffect = effectFactory.CreateEffect();
            //maskEffect.SetSourceParameter("image", profileImage);
            //maskEffect.SetSourceParameter("maskImage", maskImage);


            //EffectVisual profileImageVisual = _compositor.CreateEffectVisual();
            //profileImageVisual.Effect = maskEffect;
            //profileImageVisual.Size = size;
            //profileImageVisual.Offset = offset;

            //_rootVisual.Children.InsertAtTop(profileImageVisual);
        }

        public void Initialize(CoreApplicationView applicationView)
        {
            throw new NotImplementedException();
        }

        public void SetWindow(CoreWindow window)
        {
            _window = window;

            InitializeCompositor();

            BuildVisualTree();
        }

        public void Load(string entryPoint)
        {

        }

        public void Run()
        {
            _window.Activate();
            _window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        }

        public void Uninitialize()
        {
            throw new NotImplementedException();
        }
    }
}
