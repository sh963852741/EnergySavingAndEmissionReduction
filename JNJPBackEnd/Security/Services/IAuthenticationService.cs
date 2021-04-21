using Security.Modules;
using System;

namespace Security.Services
{
    public interface IAuthenticationService
    {
        User GetCurrentUser();
        User GetUser(Guid token);
        Guid Login(User user);
        bool Logout(Guid token);
    }
}