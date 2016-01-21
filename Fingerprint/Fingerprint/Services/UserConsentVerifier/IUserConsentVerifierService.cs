namespace Fingerprint.Services.UserConsentVerifier
{
    using System.Threading.Tasks;
    using Windows.Security.Credentials.UI;

    public interface IUserConsentVerifierService
    {
        Task<bool> CheckUserConsentAvailabilityAsync();
        Task<UserConsentVerifierAvailability> GetUserConsentAvailabilityAsync();
        Task<bool> RequestUserConsentVerificationAsync(string message);
        Task<UserConsentVerificationResult> GetRequestUserConsentVerificationAsync(string message);
    }
}
