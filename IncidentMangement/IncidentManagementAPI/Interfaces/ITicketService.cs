using IncidentManagementAPI.Models;

namespace IncidentManagementAPI.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<bool> UpdateAsync(int id, Ticket ticket);
        Task<bool> DeleteAsync(int id);
    }
}