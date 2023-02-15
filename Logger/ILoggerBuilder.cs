namespace Logger
{
    public interface ILoggerBuilder
    {
        ILoggerBuilder SetName(string name);
        ILoggerBuilder SetLevel(LogLevel level);
        ILogger Build();
    }
}
