using System;

namespace Logger.Constants
{
    public static class Message
    {
        internal const string LoggerInitializedTemplate = "Logger has been initialized: settings={0}";
        internal const string LoggerIsNotInitialized = "Logger should be initialized before using.";

        public const string VariableValueTemplate = "Variable {0} has value {1}";
        public const string VariableValueChangedTemplate = "Variable {0} value changed from {1} to {2}";

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
