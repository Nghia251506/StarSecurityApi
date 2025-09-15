using Microsoft.AspNetCore.SignalR;
using StarSecurityApi.Data;
using StarSecurityApi.Hubs;

namespace StarSecurityApi.Service
{
    public class ServiceRequestService
{
    private readonly AppDbContext _context;
    private readonly IHubContext<JobHub> _hubContext;

    public ServiceRequestService(AppDbContext context, IHubContext<JobHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }
}
}
