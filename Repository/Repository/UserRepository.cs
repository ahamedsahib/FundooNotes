using Experimental.System.Messaging;
using Fundoonotes.Models;
using Fundoonotes.Repostiory.Interface;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public bool ForgotPassword(string email)
        {
            try
            {
                var verifyEmail = this.userContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                if (verifyEmail != null)
                {
                    string url = string.Empty;
                    SendToMSMQ(email, "www.google.com");
                    bool result = ReceiveMessage(email);
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
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
        public bool SendMail(string email, string url)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("cristianomessicrlm0730@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Reset your password";
                mail.Body = $"Click this link to reset your password\n{url}";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("cristianomessicrlm0730@gmail.com", "CristianoMessi0730");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
