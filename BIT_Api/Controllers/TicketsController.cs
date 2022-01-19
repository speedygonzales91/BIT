using AutoMapper;
using BIT_Api.Managers;
using BIT_DataAccess.Data;
using BIT_Models;
using Microsoft.AspNetCore.Mvc;

namespace BIT_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private TicketsManager ticketsManager;

        public TicketsController(ApplicationDbContext db, IMapper mapper)
        {
            ticketsManager = new TicketsManager(db, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var allTickets = await ticketsManager.GetAllTickets();
            return Ok(allTickets);
        }

        [HttpGet("{parentTicketId}")]
        public async Task<IActionResult> GetChildrenTickets(int? parentTicketId)
        {
            if (parentTicketId is null)
            {
                return BadRequest(new ErrorModel { ErrorMessage = "Parent Ticket Id cannot be null" });
            }
            var childrenTickets = await ticketsManager.GetChildrenTickets(parentTicketId.Value);
            return Ok(childrenTickets);
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetTicket(int? ticketId)
        {
            if (ticketId is null)
            {
                return BadRequest(new ErrorModel() { Title = "", ErrorMessage = "Invalid Ticket Id", StatusCode = StatusCodes.Status400BadRequest });
            }

            var ticket = await ticketsManager.GetTicket(ticketId.Value);
            if (ticket is null)
            {
                return BadRequest(new ErrorModel() { Title = "", ErrorMessage = "Invalid Ticket Id", StatusCode = StatusCodes.Status404NotFound });
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                var result = await ticketsManager.CreateTicket(ticket);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while creating ticket"
                });
            }
        }

        [HttpPost("{ticketId}")]
        public async Task<IActionResult> Update(int ticketId, [FromBody] TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                var result = await ticketsManager.UpdateTicket(ticketId, ticket);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while updating ticket"
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var response = await ticketsManager.DeleteTicket(ticketId);

            if (response < 1)
            {
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "Error while deleting ticket"
                });
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
