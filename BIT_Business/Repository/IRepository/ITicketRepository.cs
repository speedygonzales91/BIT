using BIT_Models;

namespace BIT_Business.Repository.IRepository
{
    public  interface ITicketRepository
    {
        public Task<TicketDTO> CreateTicket(TicketDTO ticketDTO);
        public Task<TicketDTO> UpdateTicket(int ticketId, TicketDTO ticketDTO);
        public Task<int> DeleteTicket(int ticketId);
        public Task<TicketDTO> GetTicket(int ticketId);
        public Task<IEnumerable<TicketDTO>> GetAllTickets();
    }
}
