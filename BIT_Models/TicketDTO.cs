namespace BIT_Models
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? ProjectId { get; set; }
        public string? Status { get; set; }
        public string? AssignedTo { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Priority { get; set; }
    }
}
