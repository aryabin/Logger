using System;
using System.Threading;

namespace Logger
{
    internal class LogMessageHandler : IDisposable
    {
        private volatile static bool _started = false;

        private Thread _messageHandlerThread;

        public LogMessageHandler(LogMessageQueue queue, LogFileManager fileManager, int delay)
        {
            _messageHandlerThread = new Thread(() => Run(delay, queue, fileManager));
            _messageHandlerThread.Name = "MessageHandlerThread";
            _messageHandlerThread.IsBackground = true;
        }

        public void Start()
        {
            _started = true;
            _messageHandlerThread.Start();
        }

        public void Stop()
        {
            _started = false;
        }

        private static void Run(int delay, LogMessageQueue queue, LogFileManager fileManager)
        {
            while (_started)
            {
                Thread.Sleep(delay);
                while (!queue.IsEmpty)
                {
                    fileManager.WriteMessageToFile(queue.Dequeue());
                }
            }
        }

        public void Dispose()
        {
            _started = false;
        }
    }
}
