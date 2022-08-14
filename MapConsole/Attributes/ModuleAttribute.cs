namespace MapConsole.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute 
    {
        public bool IsPrefixed { get; }
        public string Prefix { get; }

        public ModuleAttribute(string prefix = "")
        {
            IsPrefixed = prefix != "";
            Prefix = prefix;
        }
    }
}
