public class Movie : MovieSubject
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public int Duration { get; private set; } // Duration in minutes
    public string Language { get; private set; }
    public string Description { get; private set; }

    public Movie(int id, string title, string genre, int duration, string language, string description)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Duration = duration;
        Language = language;
        Description = description;
    }
}