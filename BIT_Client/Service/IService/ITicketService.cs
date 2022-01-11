using BIT_Models;

namespace BIT_Client.Service.IService
{
    public interface ITicketService
    {
        public Task<IEnumerable<TicketDTO>> GetTickets();
        public Task<IEnumerable<TicketDTO>> GetChildrenTickets(int parentTicketId);
        public Task<TicketDTO> GetTicket(int ticketId);
        public Task<TicketDTO> CreateTicket(TicketDTO ticket);
        public Task<TicketDTO> UpdateTicket(int ticketId, TicketDTO ticket);
        public Task<int> DeleteTicket(int ticketId);
    }
}
