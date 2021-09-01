// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------

namespace Fundoonotes.Manager.Manager
{
    using System;
    using Fundoonotes.Manager.Interface;
    using Fundoonotes.Models;
    using Fundoonotes.Repostiory.Interface;
    using global::Models;

    /// <summary>
    /// User Manager
    /// </summary>
    /// <seealso cref="Fundoonotes.Manager.Interface.IUserManager" />
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IUserRepository repository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>if registration is success or not</returns>
         public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
        
        /// <summary>
        /// Logins the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>user email and password correct or wrong</returns> 
        public string Login(UserCredentialModel userData)
        {
            try
            {
                return this.repository.Login(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>email id exists or not</returns>
         public bool ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>Password update or not</returns>
        public bool ResetPassword(UserCredentialModel userData)
        {
            try
            {
                return this.repository.ResetPassword(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>generate token</returns>
         public string GenerateToken(string email)
        {
            try
            {
                return this.repository.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
