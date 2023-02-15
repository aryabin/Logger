using Logger.Configuration;
using Logger.Constants;
using System;
using System.Text;
using System.Threading;

namespace Logger
{
    internal abstract class BaseLogger : ILogger
    {
        public string Name { get; set; }
        public LogLevel Level { get; set; }
        protected static Settings Settings { get; private set; }

        protected BaseLogger()
        {
            Settings = SettingsManager.GetSettings();
            Level = Settings.Level;
            Name = String.Empty;
        }

        protected virtual string BuildLogMessage(LogLevel level, string methodName, string formatString, params object[] args)
        {
            if (Settings == null)
            {
                throw new NullReferenceException(Message.LoggerIsNotInitialized);
            }
            Settings settings = Settings;

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append(DateTime.Now.ToString(settings.Message.DateTimeFormat));
            messageBuilder.Append(settings.Message.Delimeter);
            messageBuilder.Append(Environment.CurrentManagedThreadId);
            messageBuilder.Append(settings.Message.Delimeter);
            if (!String.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                messageBuilder.Append(Thread.CurrentThread.Name);
                messageBuilder.Append(settings.Message.Delimeter);
            }
            messageBuilder.Append(level.ToString().ToUpper());
            messageBuilder.Append(settings.Message.Delimeter);
            if (!String.IsNullOrEmpty(Name))
            {
                messageBuilder.Append(Name);
                messageBuilder.Append(settings.Message.Delimeter);
            }
            if (!String.IsNullOrEmpty(methodName))
            {
                messageBuilder.Append(methodName);
                messageBuilder.Append(settings.Message.Delimeter);
            }
            messageBuilder.Append(settings.Message.Delimeter);
            messageBuilder.Append(String.Format(formatString, args));
            return messageBuilder.ToString();
        }

        public abstract void Trace(LogLevel level, string methodName, string formatString, params object[] args);

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
            Debug(methodName, Message.VariableValueTemplate, variableName, variableValue.ToString());
        }

        public void LogVariable(string variableName, object variableValue)
        {
            Debug(Message.VariableValueTemplate, variableName, variableValue.ToString());
        }

        public void LogVariableChanged(string methodName, string variableName, object oldVariableValue, object newVariableValue)
        {
            Debug(methodName, Message.VariableValueChangedTemplate, variableName, oldVariableValue.ToString(), newVariableValue.ToString());
        }

        public void LogVariableChanged(string variableName, object oldVariableValue, object newVariableValue)
        {
            Debug(Message.VariableValueChangedTemplate, variableName, oldVariableValue.ToString(), newVariableValue.ToString());
        }
    }
}
