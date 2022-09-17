using System.Diagnostics;

namespace Logger.Configuration
{
    public class FileSettings
    {
        public string Path { get; set; } = Process.GetCurrentProcess().MainModule.FileName + ".log";
        public long Size { get; set; } = 53687091200;
        public int Count { get; set; } = 5;
        public long BufferSize { get; set; } = 65536;
    }
}
