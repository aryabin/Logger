using Logger.Configuration;

namespace Logger
{
    internal delegate void SettingsChangedHandler(Settings settings);

    internal static class SettingsManager
    {
        private static Settings _settings;

        public static event SettingsChangedHandler SettingsChanged;

        public static Settings GetSettings()
        {
            if (_settings == null)
            {
                SetSettings(new Settings());
            }
            return _settings;
        }

        public static void SetSettings(Settings settings)
        {
            _settings = settings;
            SettingsChanged?.Invoke(settings);
        }
    }
}
