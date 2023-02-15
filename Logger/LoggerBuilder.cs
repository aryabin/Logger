namespace Logger
{
    internal sealed class LoggerBuilder<T> : ILoggerBuilder where T : ILogger, new()
    {
        private T _logger = new T();

        public ILogger Build()
        {
            return _logger;
        }

        public ILoggerBuilder SetName(string name)
        {
            _logger.Name = name;
            return this;
        }

        public ILoggerBuilder SetLevel(LogLevel level)
        {
            _logger.Level = level;
            return this;
        }
    }
}
