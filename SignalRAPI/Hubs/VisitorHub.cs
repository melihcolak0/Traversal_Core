using Microsoft.AspNetCore.SignalR;
using SignalRAPI.DAL;
using SignalRAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRAPI.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", "bbb");
        }
    }
}
