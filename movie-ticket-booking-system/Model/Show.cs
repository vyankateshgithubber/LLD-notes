public class Show
{
    public int ShowId { get; set; }
    public Movie Movie { get; set; }
    public Screen screen { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public IPricingStrategy priceStrategy { get; set; }

    public Show(int showId, Movie movie, Screen screen, DateTime startTime, DateTime endTime, IPricingStrategy priceStrategy)
    {
        ShowId = showId;
        Movie = movie;
        this.screen = screen;
        StartTime = startTime;
        this.priceStrategy = priceStrategy;
        EndTime = endTime;
    }
}