using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Advertising.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task ShowAsync(string message)
        {
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
    }
}
