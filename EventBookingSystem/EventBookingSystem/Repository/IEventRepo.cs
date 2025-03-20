using EventBookingSystem.Models;

namespace EventBookingSystem.Repository
{
    public interface IEventRepo
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<int> AbbEvents(Event events);

        Task<Event> GetEventById(int id);
        Task<int> Update(Event event1);
        Task<int> DeleteEvent(int id);
    }
}
