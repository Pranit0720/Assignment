using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EventBookingSystem.Models
{
//     Id 
// FirstName 
// LastName 
// Email 
// public ICollection<TicketBooking> TicketBookings
    public class User : IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public String Email { get; set; }
        //public string Id {  get; set; }
        //public IdentityUser IdentityUser { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
