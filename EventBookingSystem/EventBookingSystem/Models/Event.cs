using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingSystem.Models
{
//    Id 
// Name 
// Location 
// Date 
// AvailableSeats 
// TicketPrice 
// ICollection<TicketBooking> TicketBookings
    public class Event
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }

    }
}
