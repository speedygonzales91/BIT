
using System.ComponentModel.DataAnnotations;

namespace BIT_Models
{
    public  class ProjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A projekt nevét kötelező megadni!")]
        public string Name { get; set; }
        public double TicketPercentage { get; set; }
    }
}
