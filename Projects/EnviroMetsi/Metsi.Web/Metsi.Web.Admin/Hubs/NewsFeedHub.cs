using Microsoft.AspNetCore.SignalR;

namespace Metsi.Web.Admin.Hubs
{
    public class NewsFeedHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
