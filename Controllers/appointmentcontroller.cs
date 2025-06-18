using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using aspnetproject.Data;
using aspnetproject.Models;
using aspnetproject.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace aspnetproject.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Appointment/MentorSelection
        public async Task<IActionResult> MentorSelection()
        {
            var mentors = await _context.Mentors.ToListAsync();
            return View(mentors);
        }

        // GET: /Appointment/Book/5
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .Include(m => m.Availabilities)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mentor == null)
            {
                return NotFound();
            }

            var model = new BookAppointmentViewModel
            {
                Mentor = mentor,
                Availabilities = mentor.Availabilities
                    .Where(a => a.StartTime > DateTime.Now)
                    .OrderBy(a => a.StartTime)
                    .ToList(),
                MentorId = mentor.Id,
                Notes = string.Empty
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(BookAppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    UserId = User.Identity?.Name ?? "Unknown",  // Safely fallback if null
                    MentorId = model.MentorId,
                    StartTime = model.SelectedStartTime,
                    EndTime = model.SelectedStartTime.AddMinutes(30),
                    Notes = model.Notes ?? string.Empty,
                    Status = "Pending"
                };

                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(MyAppointments));
            }
            // Re-fetch mentor and availabilities if model invalid to redisplay form properly
            if (model.MentorId != 0)
            {
                var mentor = await _context.Mentors
                    .Include(m => m.Availabilities)
                    .FirstOrDefaultAsync(m => m.Id == model.MentorId);

                if (mentor != null)
                {
                    model.Mentor = mentor;
                    model.Availabilities = mentor.Availabilities
                        .Where(a => a.StartTime > DateTime.Now)
                        .OrderBy(a => a.StartTime)
                        .ToList();
                }
            }
            return View(model);
        }

        // GET: /Appointment/MyAppointments
        public async Task<IActionResult> MyAppointments()
        {
            var userId = User.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var appointments = await _context.Appointments
                .Include(a => a.Mentor)
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.StartTime)
                .ToListAsync();

            return View(appointments);
        }
    }
}