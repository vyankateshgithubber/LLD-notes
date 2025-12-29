public interface IFormatter
{
    string Format(LogMessage message); 
}
public class SimpleFormatter : IFormatter
{
    public string Format(LogMessage message)
    {
        return $"[{message.Timestamp:yyyy-MM-dd HH:mm:ss}] [{message.Level}] {message.Message}";
    }
}