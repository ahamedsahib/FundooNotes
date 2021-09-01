using Experimental.System.Messaging;
using Fundoonotes.Models;
using Fundoonotes.Repostiory.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fundoonotes.Repostiory.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        //private readonly IConfiguration configuration;
        private readonly IConfiguration configuration;

        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }
        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string Register(RegisterModel userData)
        {
            try
            {
                var verifyEmail = this.userContext.Users.Where(x => x.Email.Equals(userData.Email)).FirstOrDefault();
                if (verifyEmail == null)
                {
                    if (userData != null)
                    {

                        userData.Password = EncryptPassword(userData.Password);
                        this.userContext.Users.Add(userData);
                        this.userContext.SaveChanges();
                        return "Registration Successfull";
                    }
                    return "Registraion Unsuccessfull";
                }
                return "Email ID already exists";
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
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string Login(UserCredentialModel userData)
        {
            try
            {
                string message = string.Empty;
                string encodedPassword = EncryptPassword(userData.Password);
                var login = this.userContext.Users.Where(x => x.Email.Equals(userData.Email) && x.Password.Equals(encodedPassword)).FirstOrDefault();
                if (login != null)
                {
                    message = "Login Success";
                }
                else
                {
                    message = "Login failed!!!!!\nEmail or Password wrong";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Error Password Encryption" + ex.Message</exception>
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
                throw new Exception("Error Password Encryption" + ex.Message);
            }
        }
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool ForgotPassword(string email)
        {
            try
            {
                var verifyEmail = this.userContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                if (verifyEmail != null)
                {
                    string url = string.Empty;
                    SendToMSMQ(email, "wwww.passwordreset.com");
                    bool result = ReceiveMessage(email);
                    return result;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        /// <summary>
        /// Sends to MSMQ.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool SendToMSMQ(string email,string url)
        {
            MessageQueue msqueue;

            try
            {
                if (MessageQueue.Exists(@".\Private$\MyQueue"))
                {
                    msqueue = new MessageQueue(@".\Private$\MyQueue");
                }
                else
                {
                    msqueue = MessageQueue.Create(@".\Private$\MyQueue");
                }
                Message message = new Message();
                message.Formatter = new BinaryMessageFormatter();
                message.Body = url;
                msqueue.Label = "url Link";
                msqueue.Send(message);
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool ReceiveMessage(string email)
        {
            try
            {
                var receiveQueue = new MessageQueue(@".\Private$\MyQueue");
                var receiveMsg = receiveQueue.Receive();
                receiveMsg.Formatter = new BinaryMessageFormatter();
                string linkToSend = receiveMsg.Body.ToString();
                return SendMail(email, linkToSend);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool SendMail(string email, string url)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("adsahib39@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Reset your password";
                mail.Body = $"Click this link to reset your password\n{url}";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("adsahib39@gmail.com", "password");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
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
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool ResetPassword(UserCredentialModel userData)
        {
            try
            {
                var userDetails = this.userContext.Users.Where(x => x.Email.Equals(userData.Email)).FirstOrDefault();
                if (userDetails != null)
                {
                    userDetails.Password = EncryptPassword(userData.Password);
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
        public string GenerateToken(string email)
        {
            byte[] key = Convert.FromBase64String(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
