public abstract class MovieSubject
{
    private List<IMovieObserver> observers = new List<IMovieObserver>();

    public void Attach(IMovieObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IMovieObserver observer)
    {
        observers.Remove(observer);
    }

    protected void Notify(Movie movie)
    {
        foreach (var observer in observers)
        {
            observer.Update(movie);
        }
    }
}