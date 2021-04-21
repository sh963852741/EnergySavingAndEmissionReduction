using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Modules
{
    public class RecycleForm
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid CategoryID { get; set; }
        public int Credit { get; set; }
        public int Weight { get; set; }
        public string UserName { get; set; }
        public string RecycleMethod { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
    }
}
