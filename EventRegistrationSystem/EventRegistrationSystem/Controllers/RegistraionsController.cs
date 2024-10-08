using EventRegistrationSystem.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using EventRegistrationSystem.Data;
using EventRegistrationSystem.Models; // Assuming this contains the Registration model

namespace EventRegistrationSystem.Controllers
{
    public class RegistraionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EventsDbContext _context;

        public RegistraionsController(IConfiguration configuration, EventsDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch registrations from the database and pass them to the view
            var registrations = _context.Registration.ToList();
            return View(registrations);
        }

        [HttpPost]
        public  IActionResult Index(int registrationId)
        {
            // Find the registration based on the provided registrationId
            var registration = _context.Registration.Where(a => a.RegistrationId ==registrationId).First();

            if (registration != null)
            {
                // Create an instance of MailjetService and send the email
                MailjetService service = new MailjetService(_configuration);
               service.SendEmailAsync(
                    registration.Email,
                    registration.ParticipantName,
                    "<h1>Your registration has been approved!</h1>");                
            }

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            Registration regester = new Registration();
            return View(regester);
        }
        [HttpPost]
        public  IActionResult Create(Registration registration)
        {
            var regester = new Registration()
            {
              RegistrationId = registration.RegistrationId,
              Email = registration.Email,
              ParticipantName = registration.ParticipantName,
              EventId = registration.EventId
            };
            _context.Registration.Add(regester);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
