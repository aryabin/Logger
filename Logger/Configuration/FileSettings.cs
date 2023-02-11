using Logger.Constants;
using System.Diagnostics;

namespace Logger.Configuration
{
    public class FileSettings
    {
        public string Path { get; set; } = Process.GetCurrentProcess().MainModule.FileName + Constant.LogExtension;
        public long Size { get; set; } = 53687091200;
        public int Count { get; set; } = 5;
        public long BufferSize { get; set; } = 65536;

        public override string ToString()
        {
            return $"FileSettings: {{ Path:'{Path}', Size:{Size}, Count:{Count}, BufferSize:{BufferSize} }}";
        }
    }
}
