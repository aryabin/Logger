namespace Logger
{
    public static class LoggerManager
    {
        private static LoggerType _defaultLoggerType = LoggerType.File;

        public static void SetLevel(LogLevel logLevel)
        {
            SettingsManager.GetSettings().Level = logLevel;
        }

        public static void SetType(LoggerType loggerType)
        {
            _defaultLoggerType = loggerType;
        }

        public static ILogger GetLogger(string name)
        {
            ILoggerBuilder loggerBuilder = GetLoggerBuilder(_defaultLoggerType);
            loggerBuilder.SetName(name);
            return loggerBuilder.Build();
        }

        public static ILogger GetLogger(string name, LogLevel level)
        {
            ILoggerBuilder loggerBuilder = GetLoggerBuilder(_defaultLoggerType);
            loggerBuilder.SetName(name);
            loggerBuilder.SetLevel(level);
            return loggerBuilder.Build();
        }

        public static ILogger GetLogger(object obj)
        {
            return obj.GetLogger();
        }

        public static ILogger GetLogger(object obj, LogLevel level)
        {
            return obj.GetLogger(level);
        }

        public static ILoggerBuilder GetLoggerBuilder()
        {
            return GetLoggerBuilder(_defaultLoggerType);
        }

        public static ILoggerBuilder GetLoggerBuilder(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.Console:
                    return new LoggerBuilder<ConsoleLogger>();
                default:
                    return new LoggerBuilder<FileLogger>();
            }
        }
    }
}
