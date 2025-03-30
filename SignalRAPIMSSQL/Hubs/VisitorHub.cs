using Microsoft.AspNetCore.SignalR;
using SignalRAPIMSSQL.Models;
using System.Threading.Tasks;

namespace SignalRAPIMSSQL.Hubs
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
            await Clients.All.SendAsync("ReceiveVisitorList", _visitorService.GetVisitorChartList());
        }
    }
}
