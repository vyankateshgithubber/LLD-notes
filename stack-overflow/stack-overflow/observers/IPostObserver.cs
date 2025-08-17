
using StackOverflow.Observers.Events;
namespace StackOverflow.Observers
{
    public interface IPostObserver
    {
        public void OnPostEvent(Event eventObj);
    }
}