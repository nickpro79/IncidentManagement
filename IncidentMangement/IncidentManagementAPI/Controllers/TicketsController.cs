using IncidentManagementAPI.Models;
using IncidentManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetAllAsync();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            var created = await _ticketService.CreateAsync(ticket);
            return Ok(created);
        }
    }
}