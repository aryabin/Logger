namespace Logger.Constants
{
    public static class Constant
    {
        internal const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
        internal const string LogExtension = ".log";
        internal const string Tab = "\t";

        #region Method enter and exit logging
        public const string Entering = "Entering";
        public const string Leaving = "Leaving";
        public const string Minus = "-";
        public const string Plus = "+";
        #endregion

        public const string Redacted = "*REDACTED*";
        public const string ThreeStars = "***";
    }
}
