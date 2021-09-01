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
        string Register(RegisterModel userData);
        string Login(UserCredentialModel userData);
        bool ForgotPassword(string email);
        bool ResetPassword(UserCredentialModel userData);


    }
}
