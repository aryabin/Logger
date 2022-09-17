using Logger.Extensions;
using System;
using System.IO;
using System.Text;

namespace Logger
{
    internal class LogFileManager : IDisposable
    {
        private readonly int BUFFER_SIZE = 65536;

        private string _location;
        private string _name;
        private string _extension;
        private long _maxSize;
        private int _fileCount;
        private FileInfo _fileInfo;
        private StreamWriter _writer;

        public string FilePath { get; private set; }

        public LogFileManager(string path, long maxSize, int count)
        {
            _location = Path.GetDirectoryName(path);
            _name = Path.GetFileNameWithoutExtension(path);
            if (_name.EndsWith("_0", StringComparison.OrdinalIgnoreCase))
            {
                _name = _name.Substring(0, _name.Length - 2);
            }
            _extension = Path.GetExtension(path);
            _maxSize = maxSize;
            _fileCount = count;
            FilePath = Path.Combine(_location, _name + "_0" + _extension);
            _fileInfo = new FileInfo(FilePath);
            _writer = new StreamWriter(FilePath, true, Encoding.UTF8, BUFFER_SIZE);
        }

        public void WriteMessageToFile(string message)
        {
            RollUpLogFilesIfneeded();

            _writer.WriteLine(message);
            _writer.Flush();
        }

        private bool MaxSizeExceeded
        {
            get
            {
                try
                {
                    _fileInfo.Refresh();
                    return _fileInfo.Length > _maxSize;
                }
                catch (FileNotFoundException)
                {
                    return false;
                }
            }
        }

        private string GetFilePath(int number)
        {
            return Path.Combine(_location, _name + "_" + number.ToString() + _extension);
        }

        private void RollUpLogFilesIfneeded()
        {
            if (!MaxSizeExceeded)
            {
                return;
            }

            _writer.Close();
            int rollupFrom = _fileCount - 1;
            for (int i = rollupFrom; i > 0; i--)
            {
                string path = GetFilePath(i);
                if (!File.Exists(path))
                {
                    rollupFrom = i - 1;
                    continue;
                }
            }

            for (int i = rollupFrom; i >= 0; i--)
            {
                string path = GetFilePath(i);
                if (!File.Exists(path))
                {
                    continue;
                }

                FileInfo info = new FileInfo(path);
                info.MoveTo(GetFilePath(i + 1), true);
            }
            _writer = new StreamWriter(FilePath, true, Encoding.UTF8, BUFFER_SIZE);
        }

        public void Dispose()
        {
            _writer.Close();
        }
    }
}
