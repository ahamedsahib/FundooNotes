using Fundoonotes.Manager.Interface;
using Fundoonotes.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Controller.Controller
{
    public class UserController: ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                string result=this.manager.Register(userData);
                if (result.Equals("Registration Successfull"))
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = result});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status =false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Logins the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] UserCredentialModel userData)
        {
            try
            {
                string result = this.manager.Login(userData);
                if (result.Equals("Login Success"))
                {
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    return this.Ok(new { status = true, Message = result, tokenString, userData.Email });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/forgotpassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = this.manager.ForgotPassword(email);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Check Your Mail" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Error !!Email Id Not found Or Incorrect" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] UserCredentialModel userData)
        {
            try
            {
                bool result = this.manager.ResetPassword(userData);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Password Succesfully Updated" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Some Error Ocuured!!Try again" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}
