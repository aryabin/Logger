using System.Collections.Generic;

namespace Logger
{
    internal class LogMessageQueue
    {
        private object _lock = new object();
        private Queue<string> _messageQueue = new Queue<string>();

        public bool IsEmpty
        {
            get
            {
                lock (_lock)
                {
                    return _messageQueue.Count == 0;
                }
            }
        }

        public void Enqueue(string message)
        {
            lock (_lock)
            {
                _messageQueue.Enqueue(message);
            }
        }

        public string Dequeue()
        {
            lock (_lock)
            {
                return _messageQueue.Dequeue();
            }
        }
    }
}
