using Microsoft.EntityFrameworkCore;
using Security.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security
{
    public class SecurityContext:DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<RolePermissionMapping> RolePermissionMappings { get; set; }
    }
}
