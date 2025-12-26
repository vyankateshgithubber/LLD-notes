public class UserObserver : IMovieObserver
{
    private User _user;

    public UserObserver(User user)
    {
        _user = user;
    }

    public void Update(Movie movie)
    {
        // Notify the user about the movie update
        Console.WriteLine($"Notification to {_user.Name} ({_user.Email}): Movie '{movie.Title}' has been updated.");
    }
}