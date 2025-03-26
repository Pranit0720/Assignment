using EventBookingSystem.Models;
using EventBookingSystem.Repository;

namespace EventBookingSystem.Services
{
    public class TicketBookingServices:ITicketBookingServices
    {
        readonly ITicketBookingRepo _ticketBookingRepo;
        public TicketBookingServices(ITicketBookingRepo ticketBookingRepo)
        {
            _ticketBookingRepo = ticketBookingRepo;
        }

        public async Task<IEnumerable<TicketBooking>> AllBooking()
        {
            return await _ticketBookingRepo.AllBooking();
        }

        public async Task<TicketBooking> BookTicket(string userId, int eventId, int quantity)
        {
            return await _ticketBookingRepo.BookTicket(userId, eventId, quantity);
        }

        public async Task<int> CancelBookingAsync(int bookingId)
        {
            return await _ticketBookingRepo.CancelBookingAsync(bookingId);
        }

        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(string userId)
        {
            return await _ticketBookingRepo.GetBookingsByUserIdAsync(userId);
        }
    }
}
