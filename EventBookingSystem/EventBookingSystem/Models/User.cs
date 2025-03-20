namespace EventBookingSystem.Models
{
//     Id 
// FirstName 
// LastName 
// Email 
// public ICollection<TicketBooking> TicketBookings
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Email { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
