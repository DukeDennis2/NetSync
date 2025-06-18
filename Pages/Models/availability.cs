using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetproject.Models
{
    public class Availability
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MentorId { get; set; }

        public Mentor Mentor { get; set; } = null!;  // initialized as non-null with null-forgiving
    }
}