using EventBookingSystem.Models;
using System.Threading.Tasks;

namespace EventBookingSystem.Repository
{
    public interface ITicketBookingRepo
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(string userId);
        Task<TicketBooking> BookTicket(string userId, int eventId, int quantity);
        Task<int> CancelBookingAsync(int bookingId);
        Task<IEnumerable<TicketBooking>> AllBooking();

    }
}
