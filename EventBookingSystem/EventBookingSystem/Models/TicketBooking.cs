using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }  // Confirmed, Canceled


    }

    public enum BookingStatus
    {
        Confirmed,
        Canceled
    }
}