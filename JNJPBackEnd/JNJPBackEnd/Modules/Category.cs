using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Modules
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        public string Name { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
