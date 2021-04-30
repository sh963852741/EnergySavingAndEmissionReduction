using Security.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Modules
{
    public enum RecycleFormState
    {
        /// <summary>
        /// 表单被创建
        /// </summary>
        Created,
        /// <summary>
        /// 回收机填写信息
        /// </summary>
        MachineFilled,
        /// <summary>
        /// 用户提交
        /// </summary>
        UserSubmited,
        /// <summary>
        /// 处理中
        /// </summary>
        Processing,
        /// <summary>
        /// 完成
        /// </summary>
        Complete,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown
    }

    public class RecycleForm
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public User User { get; set; }
        public int Credit { get; set; }
        public int Weight { get; set; }
        public string UserName { get; set; }
        public string RecycleMethod { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public RecycleFormState State { get; set; }
    }
}
