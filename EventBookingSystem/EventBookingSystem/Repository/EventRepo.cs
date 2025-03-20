using EventBookingSystem.DBContext;
using EventBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Repository
{
    public class EventRepo : IEventRepo
    {
        readonly BookingContext _bookingContext;
        public EventRepo(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;

        }

        public async Task<int> AbbEvents(Event events)
        {
            await _bookingContext.Events.AddAsync(events);
            return await _bookingContext.SaveChangesAsync();
        }

        public async Task<int> Update(Event events1)
        {
            var events = await GetEventById(events1.Id);
            if (events != null)
            {
                events.Name = events1.Name;
                events.Location = events1.Location;
                events.Date = events1.Date;
                events.AvailableSeats = events1.AvailableSeats;
                events.TicketPrice = events1.TicketPrice;
                return await _bookingContext.SaveChangesAsync();
            }
            return 0;
        }



        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _bookingContext.Events.ToListAsync();
        }



        

        public async Task<Event> GetEventById(int id)
        {
            return await _bookingContext.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> DeleteEvent(int id)
        {
            var deleteEvent=await GetEventById(id);
            _bookingContext.Events.Remove(deleteEvent);
            return await _bookingContext.SaveChangesAsync();    
        }
    }
}
