using Fundoonotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoonotes.Repostiory.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        string Login(UserCredentialModel userData);
        bool ForgotPassword(string email);
        bool ResetPassword(UserCredentialModel userData);
    }
}
