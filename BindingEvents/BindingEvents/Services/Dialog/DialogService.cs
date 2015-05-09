namespace BindingEvents.Services.Dialog
{
    using Windows.UI.Popups;

    public class DialogService : IDialogService
    {
        public void Show(string message)
        {
            var messageDialog = new MessageDialog(message);
            var result = messageDialog.ShowAsync();
        }
    }
}
