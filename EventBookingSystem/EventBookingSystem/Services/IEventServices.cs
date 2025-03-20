using EventBookingSystem.Models;

namespace EventBookingSystem.Services
{
    public interface IEventServices
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<int> AddEvents(Event events);
        Task<int> EditEvent(Event events);
        Task<Event> GetEventById(int id);
        Task<int> Delete(int id);

    }
}
