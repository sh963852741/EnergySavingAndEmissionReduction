using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Modules
{
    public class CreditDetail
    {
        public Guid ID { get; set; }
        public Guid RecycleFormID { get; set; }
        public string Descript { get; set; }
        public int CreditChange { get; set; }
    }
}
