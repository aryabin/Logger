namespace Logger.Configuration
{
    public sealed class MessageHandlerSettings
    {
        public int Delay { get; set; } = 500;

        public override string ToString()
        {
            return $"MessageHandlerSettings: {{ Delay:{Delay} }}";
        }
    }
}
