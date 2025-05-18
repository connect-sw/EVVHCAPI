using Microsoft.AspNetCore.SignalR;

namespace EVVHCAPI.HUB
{
    public class LocationHub : Hub
    {
        public async Task SendLocation(string userId, double lat, double lng)
        {
            await Clients.All.SendAsync("ReceiveLocation", userId, lat, lng);
        }
    }
}
