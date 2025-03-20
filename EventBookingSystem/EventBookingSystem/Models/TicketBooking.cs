namespace EventBookingSystem.Models
{
//     Id 
// UserId User User 
// EventId 
// Event Event 
// Quantity 
// BookingDate 
// Status // Confirmed, Canceled
    public class TicketBooking
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int Quantity { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }  // Confirmed, Canceled


    }
}