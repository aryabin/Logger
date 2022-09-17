using System;

namespace Logger.Constants
{
    public static class Message
    {
        internal static readonly string LOGGER_INITIALIZED_TEMPLATE = "Logger has been initialized: settings={0}";
        public static readonly string VARIABLE_VALUE_TEMPLATE = "Variable {0} has value {1}";
        public static readonly string VARIABLE_VALUE_CHANGED_TEMPLATE = "Variable {0} value changed from {1} to {2}";

        public static string ApplicationStarted
        {
            get { return String.Format("{0} Application started {0}", Constant.ThreeStars); }
        }

        public static string ApplicationStopped
        {
            get { return String.Format("{0} Application stopped {0}", Constant.ThreeStars); }
        }
    }
}
