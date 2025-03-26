using EventBookingSystem.DBContext;
using EventBookingSystem.Exception;
using EventBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Repository
{
    public class TicketBookingRepo:ITicketBookingRepo
    {
        readonly BookingContext _bookingContext;
        public TicketBookingRepo(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(String userId)
        {
            return await _bookingContext.TicketBookings
                .Include(e=>e.Event)
                .Include(e => e.User)
                .Where(tb => tb.UserId == userId)
                .ToListAsync();
        }




        public async Task<TicketBooking> BookTicket(string userId, int eventId, int quantity)
        {
            var eventEntity = await _bookingContext.Events.FindAsync(eventId);
            if (eventEntity == null)
            {
                throw new EventNotFoundException($"Event with ID {eventId} not found.");
            }
            if (eventEntity.AvailableSeats < quantity)
            {
                throw new SetNotAvailableException("Not enough available seats for this booking.");
            }
            var bookig = new TicketBooking
            {
                UserId=userId,
                EventId = eventId,
                Quantity = quantity,
                BookingDate = DateTime.Now,
                Status = BookingStatus.Confirmed
            };
            eventEntity.AvailableSeats -= quantity;

            await _bookingContext.TicketBookings.AddAsync(bookig);
             await _bookingContext.SaveChangesAsync();
            return bookig;


        }

        public async Task<int> CancelBookingAsync(int bookingId)
        {
            var booking = await _bookingContext.TicketBookings.Include(s=>s.Event)
                .FirstOrDefaultAsync(tb => tb.Id == bookingId);
            booking.Status = BookingStatus.Canceled;
            booking.Event.AvailableSeats += booking.Quantity;
            return await _bookingContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TicketBooking>> AllBooking()
        {
            return await _bookingContext.TicketBookings.Include(e=>e.Event).Include(u=>u.User).ToListAsync();
             
        }














        //public async Task<int> BookTicket(string userId, int eventId, int quantity)
        //{
        //    var eventEntity = await _bookingContext.Events.FindAsync(eventId);
        //    if (eventEntity == null)
        //    {
        //        throw new EventNotFoundException($"Event with ID {eventId} not found.");
        //    }
        //    if (eventEntity.AvailableSeats < quantity)
        //    {
        //        throw new SetNotAvailableException("Not enough available seats for this booking.");
        //    }
        //    var bookig = new TicketBooking
        //    {
        //        EventId = eventId,
        //        Quantity = quantity,
        //        BookingDate = DateTime.Now,
        //        Status = BookingStatus.Confirmed
        //    };
        //    eventEntity.AvailableSeats -= quantity;

        //    await _bookingContext.TicketBookings.AddAsync(bookig);
        //    await _bookingContext.SaveChangesAsync();
        //    return bookig;
        //}



    }
}
