public interface IAppender
{
    void Append(LogMessage message);
    IFormatter GetFormatter();
    void SetFormatter(IFormatter formatter);
    void Close();
}


public class ConsoleAppender : IAppender
{
    private IFormatter formatter;
    public ConsoleAppender(IFormatter formatter)
    {
        this.formatter = formatter;
    }



    public void Append(LogMessage message)
    {
       
        string formattedMessage = formatter.Format(message);
        Console.WriteLine(formattedMessage);
    }
    public IFormatter GetFormatter()
    {
        return formatter;
    }
    public void SetFormatter(IFormatter formatter)
    {
        this.formatter = formatter;
    }
    public void Close()
    {
        // No resources to release for console appender
    }
}