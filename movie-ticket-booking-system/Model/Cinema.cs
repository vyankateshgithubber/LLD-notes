public class Cinema
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string City { get; private set; }
    public List<Screen> Screens { get ; private set; }

    public Cinema(int id, string name, string city, List<Screen> screens)
    {
        Id = id;
        Name = name;
        City = city;
        Screens = screens;
    }

}