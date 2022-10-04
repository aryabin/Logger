using System;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    internal class LogMessageHandler
    {
        private Task _messageHandlerTask;
        private CancellationTokenSource _cancellationTokenSource;

        public LogMessageHandler(LogMessageQueue queue, LogFileManager fileManager, int delay)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _messageHandlerTask = new Task(() => Run(delay, queue, fileManager), _cancellationTokenSource.Token, TaskCreationOptions.LongRunning);
        }

        public void Start()
        {
            _messageHandlerTask.Start();
        }

        private void Stop()
        {
            _cancellationTokenSource.Cancel();
            Task.WaitAll(new[] { _messageHandlerTask });
        }

        private async void Run(int delay, LogMessageQueue queue, LogFileManager fileManager)
        {
            try
            {
                await Task.Delay(delay);
                while (!queue.IsEmpty)
                {
                    fileManager.WriteMessageToFile(queue.Dequeue());
                }
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                Run(delay, queue, fileManager);
            }
            catch (OperationCanceledException) { }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
