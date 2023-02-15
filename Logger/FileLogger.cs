using Logger.Configuration;
using System;

namespace Logger
{
    internal sealed class FileLogger : BaseLogger
    {
        private static LogMessageQueue MessageQueue;
        private static LogMessageHandler MessageHandler;
        private static LogFileManager FileManager;

        static FileLogger()
        {
            SettingsManager.SettingsChanged += OnSettingsChanged;
            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                SettingsManager.SettingsChanged -= OnSettingsChanged;
                Cleanup();
            };
        }

        public FileLogger() : base() { }

        private static void Cleanup()
        {
            FileManager?.Dispose();
            MessageHandler?.Dispose();
        }

        private static void OnSettingsChanged(Settings settings)
        {
            Cleanup();
            MessageQueue = new LogMessageQueue();
            FileManager = new LogFileManager(settings.File.Path, settings.File.Size, settings.File.Count);
            MessageHandler = new LogMessageHandler(MessageQueue, FileManager, settings.Handler.Delay);
            MessageHandler.Start();
        }

        public override void Trace(LogLevel level, string methodName, string formatString, params object[] args)
        {
            if (level > Level)
            {
                return;
            }

            string message = BuildLogMessage(level, methodName, formatString, args);
            MessageQueue.Enqueue(message);
        }
    }
}
