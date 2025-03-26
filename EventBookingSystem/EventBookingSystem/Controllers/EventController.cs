using EventBookingSystem.Models;
using EventBookingSystem.Repository;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        readonly IEventServices _eventServices;
        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAllEvents()
        {
            return View(await _eventServices.GetAllEvents());
        }
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEventsForUser()
        {
            return View(await _eventServices.GetAllEvents());
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> AddEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event events)
        {
            ModelState.Remove("TicketBookings");
            if (ModelState.IsValid)
            {
                int result = await _eventServices.AddEvents(events);
                if (result > 0)
                {
                    TempData["message"] = "Event Added Succesfully!!";

                    return RedirectToAction("GetAllEvents");

                }
                else
                {
                    TempData["mess"] = "Event Addition Failed!!";
                    return View(events);
                }
                


            }
            return View(events);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _eventServices.GetEventById(id);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Event events)
        {
            await _eventServices.EditEvent(events);
            return RedirectToAction("GetAllEvents");

        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var even = await _eventServices.GetEventById(id);
            return View(even);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Event events)
        {
            var fun=await _eventServices.Delete(events.Id);
            if (fun > 0)
            {
                TempData["message"] = "Event Deleted Succesfully!!";

                return RedirectToAction("GetAllEvents");
            }
            TempData["message"] = "Event Deletion Failed!!";
            return RedirectToAction("GetAllEvents");

        }
        public async Task<IActionResult> GetEventById(int id)
        {
            var Events=await _eventServices.GetEventById(id);
            return View(Events);

        }
    }
}
