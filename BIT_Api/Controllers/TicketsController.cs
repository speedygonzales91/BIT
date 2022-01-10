using BIT_Business.Repository.IRepository;
using BIT_Models;
using Microsoft.AspNetCore.Mvc;

namespace BIT_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            this._ticketRepository = ticketRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var allTickets = await _ticketRepository.GetAllTickets();
            return Ok(allTickets);
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetTicket(int? ticketId)
        {
            if (ticketId is null)
            {
                return BadRequest(new ErrorModel() { Title = "", ErrorMessage = "Invalid Ticket Id", StatusCode = StatusCodes.Status400BadRequest });
            }

            var ticket = await _ticketRepository.GetTicket(ticketId.Value);
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
                var result = await _ticketRepository.CreateTicket(ticket);
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
                var result = await _ticketRepository.UpdateTicket(ticketId, ticket);
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
            var response = await _ticketRepository.DeleteTicket(ticketId);

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
