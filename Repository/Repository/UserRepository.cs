using Fundoonotes.Models;
using Fundoonotes.Repostiory.Interface;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Repostiory.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    
                    userData.Password = EncryptPassword(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public string Login(LoginModel userData)
        {
            try
            {
                string message = string.Empty;
                string encodedPassword = EncryptPassword(userData.password);
                var login = this.userContext.Users.Where(x => x.Email.Equals(userData.email) && x.Password.Equals(encodedPassword)).FirstOrDefault();
                if (login != null)
                {
                    message = "Login Success";
                }
                else
                {
                    message = "Login failed!!Email or password wrong";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
