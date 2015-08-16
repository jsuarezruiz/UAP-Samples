namespace PasswordVaultSample.Services.PasswordVaultService
{
    using System.Collections.Generic;
    using Windows.Security.Credentials;

    /// <summary>
    /// Represents a Credential Locker of credentials. The contents of the locker are specific to the app or service. 
    /// Apps and services don't have access to credentials associated with other apps or services.
    /// 
    /// More info: https://msdn.microsoft.com/library/windows/apps/en-us/windows.security.credentials.passwordvault.aspx
    /// </summary>
    public class PasswordVaultService : IPasswordVaultService
    {
        /// <summary>
        /// Adds a credential to the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Save(string resource, string userName, string password)
        {
            PasswordVault vault = new PasswordVault();
            PasswordCredential cred = new PasswordCredential(resource, userName, password);
            vault.Add(cred);
        }

        /// <summary>
        /// Reads a credential from the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PasswordCredential Read(string resource, string userName)
        {
            PasswordVault vault = new PasswordVault();

            return vault.Retrieve(resource, userName);
        }

        /// <summary>
        /// Retrieves all of the credentials stored in the Credential Locker.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<PasswordCredential> GetAll()
        {
            PasswordVault vault = new PasswordVault();

            return vault.RetrieveAll();
        }

        /// <summary>
        /// Removes a credential from the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        public void Delete(string resource, string userName)
        {
            PasswordVault vault = new PasswordVault();
            PasswordCredential cred = vault.Retrieve(resource, userName);
            vault.Remove(cred);
        }
    }
}
