namespace Contacts.ViewModels
{
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Navigation;
    using Services.Contacts;
    using Helpers;
    using Base;

    public class ContactsViewModel : ViewModelBase
    {
        private CollectionViewSource _contacts;

        private readonly IContactService _contactService;

        public ContactsViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }


        public CollectionViewSource Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override async Task OnNavigatedTo(NavigationEventArgs args)
        {
            await LoadContacts();
        }

        private async Task LoadContacts()
        {
            var contacts = await _contactService.GetContactCollection();

            Contacts = new CollectionViewSource
            {
                Source = contacts.Where(c => !string.IsNullOrEmpty(c.FullName)).ToAlphaGroups(c => c.FullName),
                IsSourceGrouped = true
            };
        }
    }
}
