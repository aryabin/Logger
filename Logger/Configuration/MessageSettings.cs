using Logger.Constants;

namespace Logger.Configuration
{
    public class MessageSettings
    {
        public string DateTimeFormat { get; set; } = Constant.DateTimeFormat;
        public string Delimeter { get; set; } = Constant.Tab;
        public string MethodEnterMessage { get; set; } = Constant.Plus;
        public string MethodExitMessage { get; set; } = Constant.Minus;

        public override string ToString()
        {
            return $"MessageSettings: {{ DateTimeFormat:'{DateTimeFormat}', Delimeter:'{Delimeter}', MethodEnterMessage:'{MethodEnterMessage}', MethodExitMessage:'{MethodExitMessage}' }}";
        }
    }
}
