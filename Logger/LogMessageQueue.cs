﻿using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Logger
{
    internal class LogMessageQueue
    {
        private ConcurrentQueue<string> _messageQueue = new ConcurrentQueue<string>();

        public bool IsEmpty
        {
            get { return _messageQueue.IsEmpty; }
        }

        public void Enqueue(string message)
        {
            _messageQueue.Enqueue(message);
        }

        public string Dequeue()
        {
            _messageQueue.TryDequeue(out string message);
            return message;
        }
    }
}
