using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SBSWebProject.Hubs
{
    public class MessageHub : Hub
    {
        public static void SendLogedInUser(string name)
        {
            IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            hub.Clients.All.ShowUser(name);
        }
    }
}
