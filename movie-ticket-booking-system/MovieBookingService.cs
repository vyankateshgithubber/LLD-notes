public class MovieBookingService
{
    private static volatile MovieBookingService _instance;
    private static readonly object _lock = new object();
    private Dictionary<int, Cinema> _cinemas;
    private List<IMovieObserver> _observers;
    private MovieBookingService()
    {
        _cinemas = new Dictionary<int, Cinema>();
        _observers = new List<IMovieObserver>();
    }
    public static MovieBookingService GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new MovieBookingService();
                }
            }
        }
        return _instance;
    }
    public void RegisterObserver(IMovieObserver observer)
    {
        _observers.Add(observer);
    }
    public void UnregisterObserver(IMovieObserver observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers(Movie movie)
    {
        foreach (var observer in _observers)
        {
            observer.Update(movie);
        }
    }
}