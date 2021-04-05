using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Modules
{
    public class RolePermissionMapping
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid PermissionID { get; set; }
    }
}
