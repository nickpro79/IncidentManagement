using IncidentManagementAPI.Models;

namespace IncidentManagementAPI.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> CreateAsync(Ticket ticket);
    }
}