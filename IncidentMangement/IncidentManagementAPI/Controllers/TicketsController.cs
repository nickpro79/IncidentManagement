using IncidentManagementAPI.Models;
using IncidentManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Engineer,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketService.GetAllAsync();
            return Ok(tickets);
        }
        [Authorize(Roles = "Engineer,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }
        [Authorize(Roles = "User,Engineer,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            var created = await _ticketService.CreateAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [Authorize(Roles = "Engineer,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ticket ticket)
        {
            var updated = await _ticketService.UpdateAsync(id, ticket);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ticketService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}