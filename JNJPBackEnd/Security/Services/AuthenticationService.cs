using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private Dictionary<Guid, User> userPool = new Dictionary<Guid, User>();
        private readonly SecurityContext _context;

        public Guid Login(User user)
        {
            Guid token = Guid.NewGuid();
            userPool.Add(token, user);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("token", token.ToString());
            return token;
        }

        public bool Logout(Guid token)
        {
            return userPool.Remove(token);
        }

        public User GetUser(Guid token)
        {
            return userPool[token];
        }

        public User GetCurrentUser()
        {
            string token;
            token = _httpContextAccessor.HttpContext.Request.Cookies["token"];
#if DEBUG
            if(token == null)
            {
                return u;
            }
#endif
            return userPool[Guid.Parse(token)];
        }


        private readonly User u = new()
        {
            ID = Guid.Parse("404D63C5-8B1F-4F7C-A8F0-08D904CB6845"),
            Name = "宋润涵测试",
            OpenID = "123456"
        };
    }
}
