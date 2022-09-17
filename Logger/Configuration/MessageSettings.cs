using Logger.Constants;

namespace Logger.Configuration
{
    public class MessageSettings
    {
        public string DateTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss.fff";
        public string Delimeter { get; set; } = "\t";
        public string MethodEnterMessage { get; set; } = Constant.Plus;
        public string MethodExitMessage { get; set; } = Constant.Minus;
    }
}
