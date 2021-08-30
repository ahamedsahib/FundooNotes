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
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                bool result=this.manager.Register(userData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Registratrion Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status =false, Message = "Registratrion UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                string result = this.manager.Login(userData);
                if (result.Equals("Login Success"))
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "success" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "fail" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}
