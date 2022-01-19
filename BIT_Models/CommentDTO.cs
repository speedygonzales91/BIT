
namespace BIT_Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string? Text { get; set; }
        public string? CommitUrl { get; set; }
        public bool Navigation { get; set; }
        public int? NavigationId { get; set; } //Ez az Id amelyik commentId-ból létrehoztuk
    }
}
