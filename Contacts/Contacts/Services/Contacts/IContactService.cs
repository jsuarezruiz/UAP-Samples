namespace Contacts.Services.Contacts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Contacts;
    using Windows.UI.Xaml;

    public interface IContactService
    {
        Task<List<Contact>> GetContactCollection();
        Task<Contact> PickContactPhone();
        Task<Contact> PickContactEmail();
        Task<IEnumerable<Contact>> PickContactsEmail();
        Task<IEnumerable<Contact>> PickContactsPhone();
        void ShowContactCardMini(Contact contact, FrameworkElement element);
        void ShowContactCardFull(Contact contact);
        Task InserNewContact(string firstName, string lastName, string phone, string email);
        Task<bool> DeleteContact(Contact contact);
    }
}
