using System;
using System.Collections.Generic;
using aspnetproject.Models;

namespace aspnetproject.ViewModels
{
    public class BookAppointmentViewModel
    {
        public Mentor Mentor { get; set; } = new Mentor();

        public List<Availability> Availabilities { get; set; } = new List<Availability>();

        public int MentorId { get; set; }

        public DateTime SelectedStartTime { get; set; }

        public string Notes { get; set; } = string.Empty;
    }
}