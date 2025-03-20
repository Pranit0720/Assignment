using EventBookingSystem.DBContext;
using EventBookingSystem.Models;
using EventBookingSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Tests
{
    public class EventDbTestFixture
    {
        internal BookingContext _BookingContext;
        public IEventRepo eventRepo { get; set; }
        public EventDbTestFixture()
        {
            var eventDbContextOptions = new DbContextOptionsBuilder<BookingContext>().UseInMemoryDatabase("BookingLocalDB").Options;
            var _BookingContext = new BookingContext(eventDbContextOptions);

            _BookingContext.Add(new Event { Id = 1, Name = "Event1", Location = "Mumbai", AvailableSeats = 5, });
        }

    }
}
