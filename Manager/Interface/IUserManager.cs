namespace Fundoonotes.Manager.Interface
{
    using Fundoonotes.Models;
    using global::Models;

    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string Login(UserCredentialModel userData);
        bool ForgotPassword(string email);
        bool ResetPassword(UserCredentialModel userData);
        string GenerateToken(string email);


    }
}
