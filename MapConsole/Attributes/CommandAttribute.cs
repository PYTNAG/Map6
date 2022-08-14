namespace MapConsole.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CommandAttribute : Attribute
    {
        public string Command { get; private set; }
        public CommandAttribute(string command)
        {
            Command = command;
        }
    }
}
