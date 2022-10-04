using Logger.Configuration;
using Logger.Constants;
using System;
using System.Text;
using System.Threading;

namespace Logger
{
    public class Logger : ILogger
    {
        private static readonly object Lock = new object();

        private static LogMessageQueue MessageQueue;
        private static LogMessageHandler MessageHandler;
        private static LogFileManager FileManager;
        private static Settings _settings;

        private readonly string _className;

        public static Settings Settings
        {
            get { return _settings; }
            set
            {
                lock (Lock)
                {
                    Cleanup();
                    _settings = value;

                    if (value is null)
                    {
                        return;
                    }

                    MessageQueue = new LogMessageQueue();
                    FileManager = new LogFileManager(_settings.File.Path, _settings.File.Size, _settings.File.Count);
                    MessageHandler = new LogMessageHandler(MessageQueue, FileManager, _settings.Handler.Delay);
                    MessageHandler.Start();

                    Logger logger = new Logger(typeof(Logger).Name);
                    logger.Debug(Message.LOGGER_INITIALIZED_TEMPLATE, _settings);
                }
            }
        }

        static Logger()
        {
            AppDomain.CurrentDomain.DomainUnload += (sender, e) => Cleanup();
        }

        public static ILogger GetLogger(object obj)
        {
            return new Logger(obj);
        }

        private Logger()
        {
            if (Settings == null)
            {
                Settings = new Settings();
            }
            _className = String.Empty;
        }

        private Logger(object obj) : this()
        {
            if (obj == null)
            {
                return;
            }

            if (obj is string && String.IsNullOrEmpty((string)obj))
            {
                _className = (string)obj;
            }
            else
            {
                _className = obj.GetType().Name;
            }
        }

        private static void Cleanup()
        {
            _settings = null;
            FileManager?.Dispose();
            MessageHandler?.Dispose();
        }

        public void Trace(LogLevel level, string methodName, string formatString, params object[] args)
        {
            if (_settings == null)
            {
                throw new NullReferenceException("Logger should be initialized before using.");
            }

            if (level > Settings.Level)
            {
                return;
            }

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append(DateTime.Now.ToString(Settings.Message.DateTimeFormat));
            messageBuilder.Append(Settings.Message.Delimeter);
            messageBuilder.Append(Environment.CurrentManagedThreadId);
            messageBuilder.Append(Settings.Message.Delimeter);
            if (!String.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                messageBuilder.Append(Thread.CurrentThread.Name);
                messageBuilder.Append(Settings.Message.Delimeter);
            }
            messageBuilder.Append(level.ToString().ToUpper());
            messageBuilder.Append(Settings.Message.Delimeter);
            if (!String.IsNullOrEmpty(_className))
            {
                messageBuilder.Append(_className);
                messageBuilder.Append(Settings.Message.Delimeter);
            }
            if (!String.IsNullOrEmpty(methodName))
            {
                messageBuilder.Append(methodName);
                messageBuilder.Append(Settings.Message.Delimeter);
            }
            messageBuilder.Append(Settings.Message.Delimeter);
            messageBuilder.Append(String.Format(formatString, args));

            MessageQueue.Enqueue(messageBuilder.ToString());
        }

        public void Trace(LogLevel level, string formatString, params object[] args)
        {
            Trace(level, null, formatString, args);
        }

        public void Trace(string methodName, string formatString, params object[] args)
        {
            Trace(LogLevel.Trace, methodName, formatString, args);
        }

        public void Trace(string formatString, params object[] args)
        {
            Trace(LogLevel.Trace, formatString, args);
        }

        public void Debug(string methodName, string formatString, params object[] args)
        {
            Trace(LogLevel.Debug, methodName, formatString, args);
        }

        public void Debug(string formatString, params object[] args)
        {
            Trace(LogLevel.Debug, formatString, args);
        }

        public void Info(string methodName, string formatString, params object[] args)
        {
            Trace(LogLevel.Info, methodName, formatString, args);
        }

        public void Info(string formatString, params object[] args)
        {
            Trace(LogLevel.Info, formatString, args);
        }

        public void Warn(string methodName, string formatString, params object[] args)
        {
            Trace(LogLevel.Warning, methodName, formatString, args);
        }

        public void Warn(string formatString, params object[] args)
        {
            Trace(LogLevel.Warning, formatString, args);
        }

        public void Error(string methodName, string formatString, params object[] args)
        {
            Trace(LogLevel.Error, methodName, formatString, args);
        }

        public void Error(string formatString, params object[] args)
        {
            Trace(LogLevel.Error, formatString, args);
        }

        public void Error(Exception exception, string methodName, string formatString, params object[] args)
        {
            StringBuilder errorBuilder = new StringBuilder();
            errorBuilder.AppendLine(String.Format(formatString, args));
            errorBuilder.AppendLine("EXCEPTION: " + exception.GetType().Name + " MESSAGE: " + exception.Message);
            errorBuilder.AppendLine(exception.StackTrace);

            Trace(LogLevel.Error, methodName, errorBuilder.ToString());
        }

        public void Error(Exception exception, string formatString, params object[] args)
        {
            Error(exception, null, formatString, args);
        }

        public void LogVariable(string methodName, string variableName, object variableValue)
        {
            Debug(methodName, Message.VARIABLE_VALUE_TEMPLATE, variableName, variableValue.ToString());
        }

        public void LogVariable(string variableName, object variableValue)
        {
            Debug(Message.VARIABLE_VALUE_TEMPLATE, variableName, variableValue.ToString());
        }

        public void LogVariableChanged(string methodName, string variableName, object oldVariableValue, object newVariableValue)
        {
            Debug(methodName, Message.VARIABLE_VALUE_CHANGED_TEMPLATE, variableName, oldVariableValue.ToString(), newVariableValue.ToString());
        }

        public void LogVariableChanged(string variableName, object oldVariableValue, object newVariableValue)
        {
            Debug(Message.VARIABLE_VALUE_CHANGED_TEMPLATE, variableName, oldVariableValue.ToString(), newVariableValue.ToString());
        }
    }
}
