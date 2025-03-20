namespace EventBookingSystem.Exception
{
    public class EventNotFoundException:ApplicationException
    {
        public EventNotFoundException(string mess):base(mess)
        {
            
        }
        public EventNotFoundException()
        {
            
        }
    }
}
