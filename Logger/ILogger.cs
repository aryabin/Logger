using System;

namespace Logger
{
    public interface ILogger
    {
        void Trace(LogLevel level, string methodName, string formatString, params object[] args);
        void Trace(LogLevel level, string formatString, params object[] args);
        void Trace(string methodName, string formatString, params object[] args);
        void Trace(string formatString, params object[] args);
        void Debug(string methodName, string formatString, params object[] args);
        void Debug(string formatString, params object[] args);
        void Info(string methodName, string formatString, params object[] args);
        void Info(string formatString, params object[] args);
        void Warn(string methodName, string formatString, params object[] args);
        void Warn(string formatString, params object[] args);
        void Error(string methodName, string formatString, params object[] args);
        void Error(string formatString, params object[] args);
        void Error(Exception exception, string methodName, string formatString, params object[] args);
        void Error(Exception exception, string formatString, params object[] args);

        void LogVariable(string methodName, string variableName, object variableValue);
        void LogVariable(string variableName, object variableValue);
        void LogVariableChanged(string methodName, string variableName, object oldVariableValue, object newVariableValue);
        void LogVariableChanged(string variableName, object oldVariableValue, object newVariableValue);
    }
}
