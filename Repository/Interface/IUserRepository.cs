// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Repostiory.Interface
{
    using Fundoonotes.Models;
    using global::Models;

    /// <summary>
    /// IUserRepository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>user register or not</returns>
        string Register(RegisterModel userData);

        /// <summary>
        /// Logins the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>login successful or not</returns>
        string Login(UserCredentialModel userData);

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>mail to user email</returns>
        bool ForgotPassword(string email);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>true if password updated </returns>
        bool ResetPassword(UserCredentialModel userData);

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>generate token</returns>
        string GenerateToken(string email);
    }
}
