using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetproject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}