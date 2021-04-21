using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Hubs
{
    public class RecycleHub : Hub
    {
        public void OpenBox()
        {
            Clients.All.SendAsync("Open");
        }
    }
}
