namespace Contacts.Services.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Contacts;
    using Windows.Foundation;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;

    public class ContactService : IContactService
    {
        public async Task<List<Contact>> GetContactCollection()
        {
            ContactStore allAccessStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);

            // All available contacts
            var contacts = await allAccessStore.FindContactsAsync();

            return contacts.ToList();
        }

        public async Task<Contact> PickContactPhone()
        {
            ContactPicker contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

            var contact = await contactPicker.PickContactAsync();

            return contact;
        }

        public async Task<Contact> PickContactEmail()
        {
            ContactPicker contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);

            var contact = await contactPicker.PickContactAsync();

            return contact;
        }

        public async Task<IEnumerable<Contact>> PickContactsEmail()
        {
            ContactPicker contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);

            var contacts = await contactPicker.PickContactsAsync();

            return contacts;
        }

        public async Task<IEnumerable<Contact>> PickContactsPhone()
        {
            ContactPicker contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

            var contacts = await contactPicker.PickContactsAsync();

            return contacts;
        }

        public void ShowContactCardMini(Contact contact, FrameworkElement element)
        {
            if (contact != null)
            {
                Rect rect = GetElementRect(element);

                // Show with default placement.
                ContactManager.ShowContactCard(contact, rect);
            }
        }

        public void ShowContactCardFull(Contact contact)
        {
            if (contact != null)
            {
                // Try to share the screen half/half with the full contact card.
                FullContactCardOptions options = new FullContactCardOptions
                {
                    DesiredRemainingView = ViewSizePreference.UseHalf
                };

                // Show the full contact card.
                ContactManager.ShowFullContactCard(contact, options);
            }
        }

        public async Task InserNewContact(string firstName, string lastName, string phone, string email)
        {
            var contactInfo = new Contact
            {
                FirstName = firstName,
                LastName = lastName
            };

            contactInfo.Phones.Add(new ContactPhone() { Number = phone });
            contactInfo.Emails.Add(new ContactEmail() { Address = email });

            ContactStore allAccessStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);
            var contactLists = await allAccessStore.FindContactListsAsync();

            string contactListId = string.Empty;

            if (contactLists.Count != 0)
            {
                contactListId = contactLists.FirstOrDefault().Id;
                return;
            }

            var contactList = await allAccessStore.GetContactListAsync(contactListId);

            await contactList.SaveContactAsync(contactInfo);
        }

        public async Task<bool> DeleteContact(Contact contact)
        {
            try
            {
                ContactStore allAccessStore =
                    await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);
                var contactLists = await allAccessStore.FindContactListsAsync();

                string contactListId = string.Empty;
                if (contactLists.Count != 0)
                {
                    contactListId = contactLists.FirstOrDefault().Id;
                    return false;
                }

                var contactList = await allAccessStore.GetContactListAsync(contactListId);
                await contactList.DeleteContactAsync(contact);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Rect GetElementRect(FrameworkElement element)
        {
            Windows.UI.Xaml.Media.GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
    }
}
