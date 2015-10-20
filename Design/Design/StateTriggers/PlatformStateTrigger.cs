namespace Design.StateTriggers
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Trigger for switching between Windows and Windows Phone
    /// </summary>
    public class PlatformStateTrigger : StateTriggerBase
    {
        private static string deviceFamily;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformStateTrigger"/> class.
        /// </summary>
        public PlatformStateTrigger()
        {
            if (deviceFamily == null)
            {
                var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
                deviceFamily = qualifiers.ContainsKey("DeviceFamily") ? qualifiers["DeviceFamily"] : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the device family to trigger on.
        /// </summary>
        /// <value>The device family.</value>
        public DeviceFamily DeviceFamily
        {
            get { return (DeviceFamily)GetValue(DeviceFamilyProperty); }
            set { SetValue(DeviceFamilyProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DeviceFamily"/> DependencyProperty
        /// </summary>
        public static readonly DependencyProperty DeviceFamilyProperty =
            DependencyProperty.Register("DeviceFamily", typeof(DeviceFamily), typeof(PlatformStateTrigger),
            new PropertyMetadata(DeviceFamily.Unknown, OnDeviceTypePropertyChanged));

        private static void OnDeviceTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (PlatformStateTrigger)d;
            var val = (DeviceFamily)e.NewValue;
            switch (deviceFamily)
            {
                case "Mobile":
                    obj.SetActive(val == DeviceFamily.Mobile);
                    break;
                case "Desktop":
                    obj.SetActive(val == DeviceFamily.Desktop);
                    break;
                default:
                    obj.SetActive(val == DeviceFamily.Unknown);
                    break;
            }
        }
    }

    /// <summary>
    /// Device Families
    /// </summary>
    public enum DeviceFamily
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Desktop
        /// </summary>
        Desktop = 1,
        /// <summary>
        /// Mobile
        /// </summary>
        Mobile = 2
    }
}