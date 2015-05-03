namespace Ink.ViewModels
{
    using System.Threading.Tasks;
    using Base;
    using Windows.UI.Xaml.Navigation;
    using System.Windows.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI;
    using Models;

    public class InkViewModel : ViewModelBase
    {
        // Consts
        private const int DefaultPenSize = 2;
        // Variables
        private SolidColorBrush _penColor;
        private int _penSize;
        private int _selectedPenSize;
        private PenType _penType;
        private int _selectedPenType;
        private bool _isClear;

        // Commands
        private ICommand _colorCommand;
        private ICommand _clearCommand;

        public InkViewModel()
        {
            // Init
            PenColor = new SolidColorBrush(Colors.Black);
            PenSize = 2;
            SelectedPenType = 0;
            SelectedPenSize = 1;
        }

        public SolidColorBrush PenColor
        {
            get { return _penColor; }
            set
            {
                _penColor = value;
                RaisePropertyChanged();
            }
        }

        public int PenSize
        {
            get { return _penSize; }
            set
            {
                _penSize = value;
                RaisePropertyChanged();
            }
        }

        public int SelectedPenSize
        {
            get { return _selectedPenSize; }
            set
            {
                _selectedPenSize = value;
                PenSize = DefaultPenSize * (_selectedPenSize + 1);

                RaisePropertyChanged();
            }
        }

        public PenType PenType
        {
            get { return _penType; }
            set
            {
                _penType = value;
                RaisePropertyChanged();
            }
        }

        public int SelectedPenType
        {
            get { return _selectedPenType; }
            set
            {
                _selectedPenType = value;

                switch (_selectedPenType)
                {
                    case 0:
                        PenType = PenType.Ballpoint;
                        break;
                    case 1:
                        PenType = PenType.Highlighter;
                        break;
                    case 2:
                        PenType = PenType.Calligraphy;
                        break;
                }

                RaisePropertyChanged();
            }
        }

        public bool IsClear
        {
            get { return _isClear; }
            set
            {
                _isClear = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public ICommand ColorCommand
        {
            get { return _colorCommand = _colorCommand ?? new DelegateCommand<string>(ColorCommandExecute); }
        }

        public ICommand ClearCommand
        {
            get { return _clearCommand = _clearCommand ?? new DelegateCommand(ClearCommandExecute); }
        }

        private void ColorCommandExecute(string color)
        {
            switch (color)
            {
                case "Black":
                    PenColor = new SolidColorBrush(Colors.Black);
                    break;
                case "Blue":
                    PenColor = new SolidColorBrush(Colors.Blue);
                    break;
                case "Green":
                    PenColor = new SolidColorBrush(Colors.Green);
                    break;
                case "Red":
                    PenColor = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        private void ClearCommandExecute()
        {
            IsClear = true;
            IsClear = false;
        }
    }
}
