using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.ServiceRequest;
using StarSecurityApi.Models;
using Microsoft.AspNetCore.SignalR;
using StarSecurityApi.Hubs;
using StarSecurityApi.Service;

namespace StarSecurityApi.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<JobHub> _hubContext;
        private readonly IEmailService _emailService;
        public ServiceRequestService(
        AppDbContext context,
        IHubContext<JobHub> hubContext,
        IEmailService emailService)
    {
        _context = context;
        _hubContext = hubContext;
        _emailService = emailService;
    }

        public async Task<IEnumerable<ServiceRequestReadDto>> GetAllAsync()
        {
            return await _context.ServiceRequests
                .Include(sr => sr.Service)
                .Include(sr => sr.AssignedEmployee)
                .Select(sr => new ServiceRequestReadDto
                {
                    Id = sr.Id,
                    ClientName = sr.ClientName,
                    ContactPhone = sr.ContactPhone,
                    ContactEmail = sr.ContactEmail,
                    Address = sr.Address,
                    ServiceId = sr.ServiceId,
                    ServiceName = sr.Service.Name,
                    RequestDetails = sr.RequestDetails,
                    StartDate = sr.StartDate,
                    EndDate = sr.EndDate,
                    Status = sr.Status,
                    AssignedEmployeeId = sr.AssignedEmployeeId,
                    AssignedEmployeeName = sr.AssignedEmployee != null ? sr.AssignedEmployee.FullName : null,
                    CreatedAt = sr.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ServiceRequestReadDto?> GetByIdAsync(int id)
        {
            var sr = await _context.ServiceRequests
                .Include(s => s.Service)
                .Include(s => s.AssignedEmployee)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sr == null) return null;

            return new ServiceRequestReadDto
            {
                Id = sr.Id,
                ClientName = sr.ClientName,
                ContactPhone = sr.ContactPhone,
                ContactEmail = sr.ContactEmail,
                Address = sr.Address,
                ServiceId = sr.ServiceId,
                ServiceName = sr.Service.Name,
                RequestDetails = sr.RequestDetails,
                StartDate = sr.StartDate,
                EndDate = sr.EndDate,
                Status = sr.Status,
                AssignedEmployeeId = sr.AssignedEmployeeId,
                AssignedEmployeeName = sr.AssignedEmployee?.FullName,
                CreatedAt = sr.CreatedAt
            };
        }

        public async Task<ServiceRequestReadDto> CreateAsync(ServiceRequestCreateDto dto)
        {
            var sr = new ServiceRequest
            {
                ClientName = dto.ClientName,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                Address = dto.Address,
                ServiceId = dto.ServiceId,
                RequestDetails = dto.RequestDetails,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AssignedEmployeeId = dto.AssignedEmployeeId,
                CreatedAt = DateTime.Now
            };

            _context.ServiceRequests.Add(sr);
            await _context.SaveChangesAsync();

            var result = (await GetByIdAsync(sr.Id))!;

            // 🔥 Gửi signalr cho tất cả client (admin)
            await _context.SaveChangesAsync();

            // gửi realtime
            await _hubContext.Clients.All.SendAsync("ReceiveJob", sr);

            // // gửi email
            // await _emailService.SendEmailAsync(
            //     "admin@domain.com",
            //     "Job mới",
            //     $"Có job mới từ {sr.ClientName}, dịch vụ: {sr.ServiceId}"
            // );

            return result;
        }


        public async Task<bool> UpdateAsync(int id, ServiceRequestUpdateDto dto)
        {
            var sr = await _context.ServiceRequests.FindAsync(id);
            if (sr == null) return false;

            sr.ClientName = dto.ClientName;
            sr.ContactPhone = dto.ContactPhone;
            sr.ContactEmail = dto.ContactEmail;
            sr.Address = dto.Address;
            sr.ServiceId = dto.ServiceId;
            sr.RequestDetails = dto.RequestDetails;
            sr.StartDate = dto.StartDate;
            sr.EndDate = dto.EndDate;
            sr.Status = dto.Status;
            sr.AssignedEmployeeId = dto.AssignedEmployeeId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sr = await _context.ServiceRequests.FindAsync(id);
            if (sr == null) return false;

            _context.ServiceRequests.Remove(sr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
