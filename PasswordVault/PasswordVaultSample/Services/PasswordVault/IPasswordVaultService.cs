namespace PasswordVaultSample.Services.PasswordVaultService
{
    using System.Collections.Generic;
    using Windows.Security.Credentials;

    public interface IPasswordVaultService
    {
        /// <summary>
        /// Adds a credential to the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        void Save(string resource, string userName, string password);

        /// <summary>
        /// Reads a credential from the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        PasswordCredential Read(string resource, string userName);

        /// <summary>
        /// Retrieves all of the credentials stored in the Credential Locker.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<PasswordCredential> GetAll();

        /// <summary>
        /// Removes a credential from the Credential Locker.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="userName"></param>
        void Delete(string resource, string userName);
    }
}
