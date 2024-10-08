﻿using EventRegistrationSystem.Data;
using EventRegistrationSystem.Models;
using EventRegistrationSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventRegistrationSystem.Repository.Services
{
    public class EventsServicese : IEvents
    {
        private readonly EventsDbContext _context;

        public EventsServicese(EventsDbContext context)
        {

            _context = context;
        }
        public  Event CreateEvent(Event events)
        {
            var even = new Event()
            {
                EventId = events.EventId,
                Title = events.Title,
                Date = events.Date,
                Description = events.Description,
                Capacity = events.Capacity
            };
            _context.Event.Add(even);
             _context.SaveChangesAsync();
            return events;
        }
        public  Event DeleteEvent(int Eventid)
        {
            var even = _context.Event.Where(a => a.EventId == Eventid).First();                
                _context.Event.Remove(even);
                _context.SaveChanges();                        
            return even;
        }
        public  List<Event> GetAllEvent()
        {
            var even =  _context.Event.ToList();
            return even;
        }
        public  Event GetEvent(int id)
        {
            var even =  _context.Event.Where(a => a.EventId == id).FirstOrDefault();
            return even;
        }
        public  Event UpdateEvent(Event events)
        {
            // Fetch the event from the database
            var even = _context.Event.Find(events.EventId);
            if (even == null)
            {
                throw new ArgumentException($"Event with ID {events.EventId} not found.");
            }
            // Update the properties
            even.Title = events.Title;
            even.Date = events.Date;
            even.Description = events.Description;
            even.Capacity = events.Capacity;
            // Mark the entity as modified
            _context.Entry(even).State = EntityState.Modified;
            // Save changes to the database
            _context.SaveChanges();
            return even;
        }
    }
}
