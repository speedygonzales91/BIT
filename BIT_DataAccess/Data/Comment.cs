using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_DataAccess.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public int? TicketId { get; set; }
        public string Text { get; set; }
        public string? CommitUrl { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}
