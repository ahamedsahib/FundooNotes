using Fundoonotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Manager.Interface
{
    public interface IUserManager
    {
        bool Register(RegisterModel userData);

        string Login(LoginModel userData);
        bool ForgotPassword(string email);


    }
}
