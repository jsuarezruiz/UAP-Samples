namespace SplitView.ViewModels
{
	using System.Threading.Tasks;
	using Base;
	using Windows.UI.Xaml.Navigation;
	using System.Collections.ObjectModel;
	using Models;
	using Windows.UI.Xaml;
	using System;

	public class HomeViewModel : ViewModelBase
	{
		// Variables
		private DispatcherTimer _timer;
		private ObservableCollection<string> _gallery;
		private int _selectedImage;
		private ObservableCollection<DriverStanding> _driverStanding;

		public ObservableCollection<string> Gallery
		{
			get { return _gallery; }
			set
			{
				_gallery = value;
				RaisePropertyChanged();
			}
		}

		public int SelectedImage
		{
			get { return _selectedImage; }
			set
			{
				_selectedImage = value;
				RaisePropertyChanged();
			}
		}

		public ObservableCollection<DriverStanding> DriverStanding
		{
			get { return _driverStanding; }
			set
			{
				_driverStanding = value;
				RaisePropertyChanged();
			}
		}

		public override Task OnNavigatedFrom(NavigationEventArgs args)
		{
			if (_timer != null)
				_timer.Tick -= ChangeImage;

			return null;
		}

		public override Task OnNavigatedTo(NavigationEventArgs args)
		{
			if (args.Parameter != null)
			{
				DriverStanding = args.Parameter as ObservableCollection<DriverStanding>;
			}

			LoadGallery();

			// Configure the timer
			_timer = new DispatcherTimer
			{
				//Set the interval between ticks (in this case 5 seconds to see it working)
				Interval = TimeSpan.FromSeconds(5)
			};

			// Change what's displayed when the timer ticks
			_timer.Tick += ChangeImage;

			// Start the timer
			_timer.Start();

			return null;
		}

		private void LoadGallery()
		{
			Gallery = new ObservableCollection<string>();
			for (int i = 0; i < 8; i++)
			{
				Gallery.Add(string.Format("ms-appx:///Assets/Gallery/{0}.jpg", i + 1));
			}
		}

		private void ChangeImage(object sender, object o)
		{
			// Get the number of items in the flip view
			var totalItems = Gallery.Count;
			// Figure out the new item's index (the current index plus one, if the next item would be out of range, go back to zero)
			var newItemIndex = (SelectedImage + 1) % totalItems;
			// Set the displayed item's index on the flip view
			SelectedImage = newItemIndex;
		}
	}
}
