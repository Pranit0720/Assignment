using EventBookingSystem.Models;
using EventBookingSystem.Repository;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class EventController : Controller
    {
        readonly IEventServices _eventServices;
        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }

        public async Task<IActionResult> GetAllEvents()
        {
            return View(await _eventServices.GetAllEvents());
        }

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
                int result = await _eventServices.AbbEvents(events);
                if (result > 0)
                {
                    TempData["message"] = "Book Added Succesfully!!";

                    return RedirectToAction("GetAllEvents");

                }
                else
                {
                    TempData["mess"] = "Book Addition Failed!!";
                    return View(events);
                }
                


            }
            return View(events);
        }

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
            return RedirectToAction("GetAllEvents");

        }
        public async Task<IActionResult> GetEventById(int id)
        {
            var Events=await _eventServices.GetEventById(id);
            return View(Events);

        }
    }
}
