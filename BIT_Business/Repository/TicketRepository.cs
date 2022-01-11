using AutoMapper;
using BIT_Business.Repository.IRepository;
using BIT_DataAccess.Data;
using BIT_Models;
using Html2Markdown;
using Microsoft.EntityFrameworkCore;

namespace BIT_Business.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TicketRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TicketDTO> CreateTicket(TicketDTO ticketDTO)
        {
            try
            {
                var now = DateTime.Now;
                var ticket = _mapper.Map<TicketDTO, Ticket>(ticketDTO);
                ticket.CreatedBy = "";
                ticket.CreatedOn = now;
                ticket.UpdatedBy = "";
                ticket.UpdatedOn = now;
                ticket.Description = new Html2Markdown.Converter().Convert(ticketDTO.Description);
                var addedTicket = await _db.Tickets.AddAsync(ticket);
                await _db.SaveChangesAsync();

                return _mapper.Map<Ticket, TicketDTO>(addedTicket.Entity);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<int> DeleteTicket(int ticketId)
        {
            var ticket = await _db.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                //var allImages = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
                //_db.HotelRoomImages.RemoveRange(allImages);

                _db.Tickets.Remove(ticket);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<TicketDTO>> GetAllTickets()
        {
            try
            {
                IEnumerable<TicketDTO> ticketDTOs = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(await _db.Tickets.ToListAsync());
                return ticketDTOs.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TicketDTO>> GetChildrenTickets(int parentTicketId)
        {
            try
            {
                IEnumerable<TicketDTO> ticketDTOs = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(await _db.Tickets.Where(x=>x.ParentId == parentTicketId).ToListAsync());
                return ticketDTOs.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<TicketDTO> GetTicket(int ticketId)
        {
            try
            {
                var ticket = _mapper.Map<Ticket, TicketDTO>(await _db.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId));
                return ticket;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<TicketDTO> UpdateTicket(int ticketId, TicketDTO ticketDTO)
        {
            try
            {
                if (ticketId == ticketDTO.Id)
                {
                    var ticketDetail = await _db.Tickets.FindAsync(ticketId);
                    var ticket = _mapper.Map<TicketDTO, Ticket>(ticketDTO, ticketDetail);
                    ticket.UpdatedBy = "";
                    ticket.UpdatedOn = DateTime.Now;
                    ticket.Description = new Html2Markdown.Converter().Convert(ticketDTO.Description);
                    var updatedTicket = _db.Tickets.Update(ticket);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Ticket, TicketDTO>(updatedTicket.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
