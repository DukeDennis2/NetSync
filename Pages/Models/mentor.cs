using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetproject.Models
{
    public class Mentor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Availability> Availabilities { get; set; } = new List<Availability>();
    }
}