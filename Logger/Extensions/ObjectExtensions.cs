using System;

namespace Logger
{
    public static class ObjectExtensions
    {
        public static ILogger GetLogger(this object obj)
        {
            string name = GetLoggerName(obj);

            return LoggerManager.GetLogger(name);
        }

        public static ILogger GetLogger(this object obj, LogLevel level)
        {
            string name = GetLoggerName(obj);

            return LoggerManager.GetLogger(name, level);
        }

        public static ILoggerBuilder GetLoggerBuilder(this object obj, LoggerType loggerType = LoggerType.File)
        {
            string name = GetLoggerName(obj);

            return LoggerManager.GetLoggerBuilder(loggerType).SetName(name);
        }

        private static string GetLoggerName(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }

            if (obj is string && !String.IsNullOrWhiteSpace((string)obj))
            {
                return (string)obj;
            }

            return obj.GetType().Name;
        }
    }
}
