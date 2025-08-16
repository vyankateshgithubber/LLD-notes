namespace StackOverflow.Models
{
    public class Tag
{
    private string name;

    public Tag(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}
}
