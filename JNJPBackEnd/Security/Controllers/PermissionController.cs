using Microsoft.AspNetCore.Mvc;
using Security.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Controllers
{
    [ApiController]
    [Route("~/api/authorize/[action]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly SecurityContext _context;

        public AuthorizeController(SecurityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            List<Role> roles = _context.Roles.ToList();
            return Ok(new
            {
                success = true,
                data = roles
            });
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRoles), new
            {
                success = true,
                data = role
            });
        }

        [HttpDelete]
        public ActionResult RemoveRole(Guid id)
        {
            Role role = _context.Roles.SingleOrDefault(role => role.ID == id);
            if (role == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "角色不存在"
                });
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();

            return Ok(new
            {
                success = true
            });
        }

        [HttpPost]
        public ActionResult GrantUserRole(List<Guid> roleIds, Guid userId)
        {
            User user = _context.Users.SingleOrDefault(user => user.ID == userId);
            if (user == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "用户不存在"
                });
            }

            List<Role> roles = _context.Roles.Where(e => roleIds.Contains(e.ID)).ToList();

            List<UserRoleMapping> mappings = new List<UserRoleMapping>();
            foreach (Role role in roles)
            {
                mappings.Add(new UserRoleMapping()
                {
                    UserID = user.ID,
                    RoleID = role.ID
                });
            }

            _context.UserRoleMappings.AddRange(mappings);
            _context.SaveChanges();

            return Ok(new
            {
                success = true
            });
        }
    }
}
