namespace BindingEvents.Models
{
    using System.Diagnostics;
    using Windows.UI.Xaml;

    public class House
    { 
        public string Name { get; set; }

        public void Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(string.Format("Clicked {0}!", Name));
        }
    }
}
