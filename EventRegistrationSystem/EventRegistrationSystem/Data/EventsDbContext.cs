using EventRegistrationSystem.Models;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationSystem.Data
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Event { get; set; }
        public DbSet<Registration> Registration { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Add relationshps (One - to - Many)
            modelBuilder.Entity<Event>()
               .HasMany(e => e.Registrations)
               .WithOne(r => r.Event)
               .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Event>().HasData(
               new Event
               {
                   EventId = 1,
                   Title = "Tech Conference 2024",
                   Date = new DateTime(2024, 11, 10),
                   Capacity = 100,
                   Description = "Annual technology conference focusing on software development."
               },
               new Event
               {
                   EventId = 2,
                   Title = "AI Workshop",
                   Date = new DateTime(2024, 12, 5),
                   Capacity = 50,
                   Description = "A hands-on workshop to explore AI and machine learning."
               },
               new Event
               {
                   EventId = 3,
                   Title = "Cybersecurity Summit",
                   Date = new DateTime(2024, 11, 20),
                   Capacity = 75,
                   Description = "A summit discussing the latest trends in cybersecurity."
               });
        }
    }
}
