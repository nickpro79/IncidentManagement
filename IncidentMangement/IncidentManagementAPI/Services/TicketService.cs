using IncidentManagementAPI.Data;
using IncidentManagementAPI.Models;
using IncidentManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagementAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> UpdateAsync(int id, Ticket updatedTicket)
        {
            var existing = await _context.Tickets.FindAsync(id);

            if (existing == null)
                return false;

            existing.Title = updatedTicket.Title;
            existing.Description = updatedTicket.Description;
            existing.Priority = updatedTicket.Priority;
            existing.Status = updatedTicket.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
                return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}