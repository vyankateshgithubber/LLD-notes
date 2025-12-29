public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warn,
    Error,
    Fatal
}
public static class LogLevelExtensions
{
    public static bool IsGreaterOrEqual(this LogLevel level, LogLevel other)
    {
        return level >= other;
    }
}