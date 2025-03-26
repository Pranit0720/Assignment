using EventBookingSystem.Models;

namespace EventBookingSystem.Services
{
    public interface ITicketBookingServices
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(string userId);
        Task<TicketBooking> BookTicket(string userId, int eventId, int quantity);
        Task<int> CancelBookingAsync(int bookingId);
        Task<IEnumerable<TicketBooking>> AllBooking();


    }
}
