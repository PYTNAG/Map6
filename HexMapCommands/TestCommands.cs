using MapConsole.Attributes;

namespace HexMapCommands
{
    [Module]
    public static class TestCommands
    {
        [Command("echo")]
        public static string Echo(string[] args)
        {
            return string.Join(' ', args);
        }
    }
}