using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Repository.Interfaces
{
    public interface IEvents
    {
        public List<Event> GetAllEvent();
        public Event GetEvent(int id);
        public Event CreateEvent(Event events);
        public Event UpdateEvent(Event events);
        public Event DeleteEvent(int id);
    }
}
