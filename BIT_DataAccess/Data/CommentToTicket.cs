
using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_DataAccess.Data
{
    public class CommentToTicket
    {
        public int Id { get; set; }
        public int? CommentId { get; set; }
        public int? TicketId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
