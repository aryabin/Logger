using System.Text.Encodings.Web;
using System.Text.Json;

namespace Logger.Configuration
{
    public class Settings
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
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            return JsonSerializer.Serialize<Settings>(this, options);
        }
    }
}
