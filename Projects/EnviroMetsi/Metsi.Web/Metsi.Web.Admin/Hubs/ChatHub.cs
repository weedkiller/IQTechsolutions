using Microsoft.AspNetCore.SignalR;

namespace Metsi.Web.Admin.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
