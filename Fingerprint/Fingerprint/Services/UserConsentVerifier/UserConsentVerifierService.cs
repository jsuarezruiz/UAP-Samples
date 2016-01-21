namespace Fingerprint.Services.UserConsentVerifier
{
    using System;
    using System.Threading.Tasks;
    using Windows.Security.Credentials.UI;

    public class UserConsentVerifierService : IUserConsentVerifierService
    {
        public async Task<bool> CheckUserConsentAvailabilityAsync()
        {
            try
            {
                UserConsentVerifierAvailability consentAvailability =
                    await UserConsentVerifier.CheckAvailabilityAsync();

                if (consentAvailability == UserConsentVerifierAvailability.Available)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserConsentVerifierAvailability> GetUserConsentAvailabilityAsync()
        {
            UserConsentVerifierAvailability consentAvailability =
                await UserConsentVerifier.CheckAvailabilityAsync();

            return consentAvailability;
        }

        public async Task<bool> RequestUserConsentVerificationAsync(string message)
        {
            try
            {
                UserConsentVerificationResult consentResult =
                    await UserConsentVerifier.RequestVerificationAsync(message);

                if (consentResult == UserConsentVerificationResult.Verified)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserConsentVerificationResult> GetRequestUserConsentVerificationAsync(string message)
        {
            UserConsentVerificationResult consentResult =
                await UserConsentVerifier.RequestVerificationAsync(message);

            return consentResult;
        }
    }
}
