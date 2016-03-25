using System.Threading.Tasks;

namespace Advertising.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowAsync(string message);
    }
}
