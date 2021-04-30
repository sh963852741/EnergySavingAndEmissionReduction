using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Modules
{
    [Table("Permissions")]
    public class Permission
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
