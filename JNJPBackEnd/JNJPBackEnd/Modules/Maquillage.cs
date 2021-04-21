using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Modules
{
    public class Maquillage
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        /// <summary>
        /// 化妆品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        public string Manufacture { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
