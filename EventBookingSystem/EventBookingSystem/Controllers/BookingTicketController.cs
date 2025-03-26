using EventBookingSystem.Exception;
using EventBookingSystem.Models;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventBookingSystem.Controllers
{
    [Authorize]
    public class BookingTicketController : Controller
    {
        readonly ITicketBookingServices _TicketBooingServices;
        readonly IEventServices _eventServices;
        public BookingTicketController(ITicketBookingServices ticketBookingServices, IEventServices eventServices)
        {
            _eventServices = eventServices;
            _TicketBooingServices = ticketBookingServices;
        }
        [HttpGet]
        public async Task<IActionResult> MyBookings()
        {

            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }
            var booking = await _TicketBooingServices.GetBookingsByUserIdAsync(userId);
            //if (booking == null) 
            //{ 
            //    throw new 
            //}
            return View(booking);
        }

        //public async Task<IActionResult> MyBookingsForUser()
        //{

        //    var userId = HttpContext.Session.GetString("UserId");
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    var booking = await _TicketBooingServices.GetBookingsByUserIdAsync(userId);
        //    //if (booking == null) 
        //    //{ 
        //    //    throw new 
        //    //}
        //    return View(booking);
        //}
        [HttpGet]
        public async Task<IActionResult> BookTickets(int id)
        {
            var eventInfo= await _eventServices.GetEventById(id);
            ViewBag.EventDetail = eventInfo.TicketPrice;
            ViewBag.EventId = id;

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> BookTickets(TicketBooking ticketBooking)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var booking = new TicketBooking
            {
                UserId = userId,
                EventId = ticketBooking.EventId,
                Quantity = ticketBooking.Quantity,
                BookingDate = DateTime.Now,
                Status = BookingStatus.Confirmed


            };
            var createBooking = await _TicketBooingServices.BookTicket(userId, ticketBooking.EventId, ticketBooking.Quantity);

            
            return RedirectToAction("GetAllEventsForUser", "Event");

            


        }
        [HttpPost]

        public async Task<IActionResult> CancelBooking(int id)
        {
            await _TicketBooingServices.CancelBookingAsync(id);
            return RedirectToAction("MyBookings");
        }

        [HttpGet]
        public async Task<IActionResult> AllBookings()
        {
            return View(await _TicketBooingServices.AllBooking());
            

        }





    }
}
