using JNJPBackEnd.Modules;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Hubs
{
    public class RecycleHub : Hub
    {
        private readonly JNJPContext _context;
        public RecycleHub(JNJPContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 使指定ID机器的箱子打开
        /// </summary>
        public void OpenBox(Guid formID)
        {
            Clients.All.SendAsync("OpenBox", formID);
        }

        /// <summary>
        /// 接收箱子关闭的消息
        /// </summary>
        public void BoxClosed(Guid formID, int weight)
        {
            RecycleForm form = _context.RecycleForms.Find(formID);
            if(form == null)
            {
                Clients.Caller.SendAsync("Confirm", "表格ID不存在");
                return;
            }
            form.Weight = weight;
            form.State = RecycleFormState.MachineFilled;
            _context.SaveChanges();

            Clients.Caller.SendAsync("Confirm");
        }
    }
}
