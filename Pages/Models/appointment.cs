using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetproject.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int MentorId { get; set; }

        public Mentor Mentor { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;
    }
}