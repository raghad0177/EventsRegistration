using EventRegistrationSystem.Models;
using EventRegistrationSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace EventRegistrationSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEvents _context;
        public EventsController(IEvents context)
        {
            _context = context;
        }
        //Get All
        public IActionResult Index()
        {
            var allEvents = _context.GetAllEvent();
            return View(allEvents);
        }
        //Get By Id
        public IActionResult GetById(int id)
        {
            var getById = _context.GetEvent(id);
            return View(getById);
        }
        //Create
        public IActionResult Create()
        {
            Event even = new Event();
            return View(even);
          
        }
        [HttpPost]
        public IActionResult Create(Event events)
        {
            _context.CreateEvent(events);
            return RedirectToAction("Index");
        }
        //Delete
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _context.DeleteEvent(id);
            return RedirectToAction("Index");
        }
        //Update
        public IActionResult Update()
        {
            Event even = new Event();
            return View(even);
        }
        [HttpPost]
        public IActionResult Update(Event events)
        {
             _context.UpdateEvent(events);
            return RedirectToAction("Index");
        }
    }
}
