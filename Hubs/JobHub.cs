using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace StarSecurityApi.Hubs
{
    public class JobHub : Hub
    {
        public async Task SendJobNotification(object job)
        {
            await Clients.All.SendAsync("ReceiveJob", job);
        }
    }
}
