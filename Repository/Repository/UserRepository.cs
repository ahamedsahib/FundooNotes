// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Repostiory.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using Fundoonotes.Models;
    using Fundoonotes.Repostiory.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using global::Models;
    using global::Repository.Context;
    using StackExchange.Redis;

    /// <summary>
    /// user repository class
    /// </summary>
    /// <seealso cref="Fundoonotes.Repostiory.Interface.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        /// <param name="configuration">The configuration.</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>encrypted data</returns>
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
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>registration is successful or not</returns>
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
        /// <returns>user email and password correct or wrong</returns> 
        public string Login(UserCredentialModel userData)
        {
            try
            {
                string message = string.Empty;
                string encodedPassword = EncryptPassword(userData.Password);
                var login = this.userContext.Users.Where(x => x.Email.Equals(userData.Email) && x.Password.Equals(encodedPassword)).FirstOrDefault();
                if (login != null)
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(key: "FirstName", login.FirstName);
                    database.StringSet(key: "LastName", login.LastName);
                    database.StringSet(key: "UserID", login.UserId.ToString());
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
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>email id exists or not</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                var verifyEmail = this.userContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                if (verifyEmail != null)
                {
                    string url = string.Empty;
                    this.SendToMSMQ("wwww.passwordreset.com");
                    bool result = this.SendEmail(email);
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
        /// <param name="url">The URL.</param>
        /// <returns>return true if message exists</returns>
        public bool SendToMSMQ(string url)
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <returns>url to reset password</returns>
        public string ReceiveMessage()
        {
            try
            {
                var receiveQueue = new MessageQueue(@".\Private$\MyQueue");
                var receiveMsg = receiveQueue.Receive();
                receiveMsg.Formatter = new BinaryMessageFormatter();
                string linkToSend = receiveMsg.Body.ToString();
                return linkToSend;
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
        /// <returns>mail to client</returns>
        public bool SendEmail(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("adsahib39@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Reset your password";
                mail.Body = $"Click this link to reset your password\n{this.ReceiveMessage()}";
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("adsahib39@gmail.com", "password");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
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
        /// <returns>password updated or not</returns>
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
       
        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>generated token</returns>
        public string GenerateToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
