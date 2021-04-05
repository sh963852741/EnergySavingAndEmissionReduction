using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Modules
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string OpenID { get; set; }
        public string Password { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
