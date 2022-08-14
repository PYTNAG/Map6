using MapConsole.Attributes;

namespace HexMap
{
    [Module]
    public class ConsoleCommands
    {
        [Command("clear")]
        public static string Clear(string[] args)
        {
            return "SYS:CONSOLE:CLEAR";
        }
    }
}
