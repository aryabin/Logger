using System.Text;

namespace Logger.Configuration
{
    public sealed class Settings
    {
        public LogLevel Level { get; set; } = LogLevel.Debug;
        public FileSettings File { get; set; }
        public MessageSettings Message { get; set; }
        public MessageHandlerSettings Handler { get; set; }

        public Settings()
        {
            File = new FileSettings();
            Message = new MessageSettings();
            Handler = new MessageHandlerSettings();
        }

        public Settings(string path = null, LogLevel logLevel = LogLevel.Info, long maxSize = 53687091200, int count = 5) : this()
        {
            Level = logLevel;
            File.Path = path ?? File.Path;
            File.Size = maxSize;
            File.Count = count;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tLevel:{Level}");
            stringBuilder.AppendLine($"\t{File}");
            stringBuilder.AppendLine($"\t{Message}");
            stringBuilder.AppendLine($"\t{Handler}");
            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }
}
