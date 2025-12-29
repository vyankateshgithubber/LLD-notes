public class LogMessage
{
    public DateTime Timestamp { get; }
    public LogLevel Level { get; }
    public string Message { get; }
    public string LoggerName { get; }
    public string ThreadName { get; }
    public LogMessage(LogLevel level, string message, string loggerName)
    {
        Timestamp = DateTime.Now;
        Level = level;
        Message = message;
        LoggerName = loggerName;
        ThreadName = System.Threading.Thread.CurrentThread.Name ?? $"Thread-{System.Threading.Thread.CurrentThread.ManagedThreadId}";
    }
}