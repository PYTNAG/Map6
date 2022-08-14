using System.Text;
using MapConsole.Attributes;

namespace HexMapCommands
{
    [Module(prefix: "map")]
    public static class MapCommands
    {
        private static readonly Dictionary<string, MapSettings> _settings = new Dictionary<string, MapSettings>(1)
            {
                {
                    "default",
                    new MapSettings
                    {
                        hexRadius = 20.0f,
                        width = 25,
                        height = 25,
                        markup = MapMarkup.FourQuadrants,
                        positiveDirection = Direction.NE
                    }
                }
            };

        private static string _currentSettingsName = "default";

        [Command("current")]
        public static string[] CurrentSettings(string[] args)
        {
            return SettingsDescription(new[] { _currentSettingsName });
        }

        [Command("settings")]
        public static string[] Settings(string[] args)
        {
            var keys = _settings.Keys.Select(k => $"- {k}").ToArray();
            return new[] { "=== settings ===\n" + string.Join('\n', keys) };
        }

        [Command("set")]
        public static string[] SetSettings(string[] args)
        {
            if (!_settings.ContainsKey(args[0]))
                return new[] { "Unknown settings name" };

            _currentSettingsName = args[0];
            return new[] { $"Current settings {args[0]}" };
        }

        [Command("desc")]
        public static string[] SettingsDescription(string[] args)
        {
            if (!_settings.ContainsKey(args[0]))
                return new[] { "Unknown settings name" };

            MapSettings settings = _settings[args[0]];
            return new[] { 
                $"=== {args[0]} ===" +
                $"\nRadius: {settings.hexRadius}" +
                $"\nSize: {settings.width}x{settings.height}" +
                $"\nMarkup: {settings.markup}" +
                $"\nDirection: {settings.positiveDirection}" 
            };
        }

        [Command("draw")]
        public static string[] Draw(string[] args)
        {
            MapSettings settings = _settings[_currentSettingsName];
            return new[] { $"SYS:DRAW:R/{settings.hexRadius}:W/{settings.width}:H/{settings.height}:M/{settings.markup}:D/{settings.positiveDirection}" };
        }

        [Command("save")]
        public static string[] Save(string[] args)
        {
            return new[] { $"SYS:SAVE:{args[0]}" };
        }
    }
}
