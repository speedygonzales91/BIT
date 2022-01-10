using System.ComponentModel.DataAnnotations.Schema;

namespace BIT_DataAccess.Data
{
    public class CommentFile
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int FileId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
        [ForeignKey("FileId")]
        public virtual File File { get; set; }
    }
}
