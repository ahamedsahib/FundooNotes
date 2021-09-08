// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="TVSNext">
//   Copyright © 2021 Company="TVSNext"
// </copyright>
// <creator name="Ahamed"/>
// ----------------------------------------------------------------------------------------------------------
namespace Fundoonotes.Controller.Controller
{
    using System;
    using Fundoonotes.Manager.Interface;
    using Fundoonotes.Models;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// UserController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IUserManager manager;

        private readonly ILogger<UserController> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            _logger = logger;
        }

        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>successfully user register or not</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                _logger.LogInformation("Register method called!!!");
                string result = this.manager.Register(userData);
                if (result.Equals("Registration Successfull"))
                {
                    _logger.LogInformation($"{userData.FirstName} Registerd Succesfully");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                
                _logger.LogInformation("Registration Failed");
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Some Error Occured while Registration");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        
        /// <summary>
        /// Logins the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>user logged in or not</returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] UserCredentialModel userData)
        {
            try
            {
                _logger.LogInformation("Login method called!!!");
                string result = this.manager.Login(userData);
                if (result.Equals("Login Success"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string FirstName = database.StringGet("FirstName");
                    string LastName = database.StringGet("LastName");
                    int UserId = Convert.ToInt32(database.StringGet("UserID"));
                    RegisterModel data = new RegisterModel
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        UserId = UserId,
                        Email = userData.Email
                    };
                    _logger.LogInformation($"{userData.Email} Login Succesfully");
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    return this.Ok(new { Status = true, Message = result, tokenString, userData.Email ,UserData= data});
                }
                else
                {
                    _logger.LogInformation("Login Failed");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Some Error Occured while Login");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        
        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>email id is exists or not</returns>
        [HttpGet]
        [Route("api/forgotpassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                _logger.LogInformation("Forgot Password method called!!!");
                var result = this.manager.ForgotPassword(email);
                if (result)
                {
                    _logger.LogInformation($"{email} Got mail to Reset Password");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Check Your Mail" });
                }
                else
                {
                    _logger.LogInformation("Error ! Email Id Not found to Reset Password");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error !!Email Id Not found Or Incorrect" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Some Error Occured while Changing Password");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>password update or not</returns>
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] UserCredentialModel userData)
        {
            try
            {
                _logger.LogInformation("Reset Password method called!!!");
                bool result = this.manager.ResetPassword(userData);
                if (result)
                {
                    _logger.LogInformation($"{userData.Email} Reset Password Succesfully");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Succesfully Updated" });
                }
                else
                {
                    _logger.LogInformation("Error ! Email Id Not found to Reset Password");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Some Error Ocuured!!Try again" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Some Error Occured while Resting Password");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
