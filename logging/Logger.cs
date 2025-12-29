using System;
using System.Collections.Generic;

public class Logger
{
    private readonly string name;
    private LogLevel? level;
    private readonly Logger? parent;
    private readonly List<IAppender> appenders;
    private bool IsAdditive =  true;
    public Logger(string name, Logger? parent = null)
    {
        this.name = name;
        this.level = null;
        this.parent = parent;
        this.appenders = new List<IAppender>();
    }

    public void AddAppender(IAppender appender)
    {
        appenders.Add(appender);
    }
    public List<IAppender> GetAppenders()
    {
        return appenders;
    }

    public void SetMinimumLevel(LogLevel lvl)
    {
        // Logic to set minimum log level
        this.level = lvl;
    }
    public LogLevel GetEffectiveLevel()
    {
        if (level.HasValue)
        {
            return level.Value;
        }
        else if (parent != null)
        {
            return parent.GetEffectiveLevel();
        }
        else
        {
            return LogLevel.Debug; // Default level
        }
    }

    public void Log(LogLevel logLevel, string message)
    {
        if (logLevel.IsGreaterOrEqual(GetEffectiveLevel()))
        {
            var logMessage = new LogMessage(logLevel, message, name);

            foreach (var appender in appenders)
            {
                appender.Append(logMessage);
            }

            if (IsAdditive && parent != null)
            {
                parent.Log(logLevel, message);
            }
        }
    }
    public void Debug(string message)
    {
        Log(LogLevel.Debug, message);
    }
    public void Info(string message)
    {
        Log(LogLevel.Info, message);
    }
    public void Warn(string message)
    {
        Log(LogLevel.Warn, message);
    }
    public void Error(string message)
    {
        Log(LogLevel.Error, message);
    }
    public void Fatal(string message)
    {
        Log(LogLevel.Fatal, message);
    }
}