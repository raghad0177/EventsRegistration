namespace EventRegistrationSystem.Models
{
    public class Event
    {
        //Title, Date, Description, Capacity
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
