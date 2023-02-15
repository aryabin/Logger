using System;

namespace Logger
{
    internal sealed class ConsoleLogger : BaseLogger
    {
        public override void Trace(LogLevel level, string methodName, string formatString, params object[] args)
        {
            if (level > Level)
            {
                return;
            }

            string message = BuildLogMessage(level, methodName, formatString, args);
            Console.WriteLine(message);
        }
    }
}
