
using System.ComponentModel.DataAnnotations;

namespace BIT_DataAccess.Data
{
    public  class File
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
    }
}
