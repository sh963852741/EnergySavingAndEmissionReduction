using Microsoft.AspNetCore.Mvc;
using Security.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Services
{
    public class AuthenticationService
    {
        private Dictionary<Guid, User> userPool;
        private readonly SecurityContext _context;

        public Guid Login(Guid userId)
        {
            User user = _context.Users.SingleOrDefault(e => e.ID == userId);
            if(user == null)
            {
                return Guid.Empty;
            }

            Guid token = Guid.NewGuid();
            userPool.Add(token, user);
            return token;
        }

        public bool Logout(Guid token)
        {
            return userPool.Remove(token);
        }
    }
}
