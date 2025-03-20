using EventBookingSystem.Exception;
using EventBookingSystem.Models;
using EventBookingSystem.Repository;
using Microsoft.Extensions.Logging;

namespace EventBookingSystem.Services
{
    public class EventServices:IEventServices
    {
        readonly IEventRepo _eventRepo;
        public EventServices(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<int> AddEvents(Event events)
        {
            return await _eventRepo.AddEvents(events);
        }

        public async Task<int> EditEvent(Event events)
        {
            return await _eventRepo.Update(events);
        }
        public async Task<Event> GetEventById(int id)
        {
            var events=await _eventRepo.GetEventById(id);
            if (events == null)
            {
                throw new EventNotFoundException($"Event Id:{id} is not exists!!");
            }
            return events;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepo.GetAllEvents();
        }

        public async Task<int> Delete(int id)
        {
            return await _eventRepo.DeleteEvent(id);
        }
    }
}
