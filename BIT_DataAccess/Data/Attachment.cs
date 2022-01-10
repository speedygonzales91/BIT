using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_DataAccess.Data
{
    public class Attachment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string AttachmentUrl { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
