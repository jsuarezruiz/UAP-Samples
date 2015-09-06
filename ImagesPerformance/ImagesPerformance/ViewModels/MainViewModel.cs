namespace ImagesPerformance.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using System.Collections.ObjectModel;

    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<string> _images;

        public ObservableCollection<string> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            Images = new ObservableCollection<string>
            {
                "http://www.hdwallpapers.in/download/hulk_vs_hulkbuster-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/minions_in_new_york-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/ridley_scott_the_martian-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/the_hunger_games_mockingjay_part_2_2015-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/spcae_work-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/2015_lamborghini_aventador_roadster_prestige_imports-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/emilia_clarke_daenerys_game_of_thrones-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/charlize_theron_mad_max_fury_road-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/jurassic_world_bryce_dallas_howard-3840x2160.jpg",
                "http://www.hdwallpapers.in/download/inside_out_joy_sadness-3840x2160.jpg"
            };

            return null;
        }

        private void LoadImages()
        {

        }
    }
}
