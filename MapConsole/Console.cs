using MapConsole.Attributes;
using System.Reflection;

namespace MapConsole
{
    public class Console
    {
        public char OutputPrefix { get; }
        private readonly char _prefixChar;

        private readonly List<Type> _sysModules;
        private readonly List<Type> _prefixedModules;

        public Console(char outputPrefix = '>', char commandPrefixChar = '/')
        {
            OutputPrefix = outputPrefix;
            _prefixChar = commandPrefixChar;

            _sysModules = new List<Type>();
            _prefixedModules = new List<Type>();
        }

        public IEnumerable<string> ParseInput(string input) // {prefix char}[prefix] {command} {args} 
        {
            if (input.Length == 0 || input[0] != _prefixChar)
                return Array.Empty<string>();

            string[] inputStruct = input.Split(' ');
            string id = inputStruct[0][1..];
            IEnumerable<Type> matchedModules = _prefixedModules.Where(m => m.GetCustomAttribute<ModuleAttribute>()?.Prefix == id);

            if (!matchedModules.Any())
            {
                return InvokeCommands(_sysModules, id, inputStruct.Skip(1).ToArray());
            }
            else
            {
                return InvokeCommands(matchedModules, inputStruct[1], inputStruct.Skip(2).ToArray());
            }
        }

        private IEnumerable<string> InvokeCommands(IEnumerable<Type> modules, string command, string[] args)
        {
            List<string> result = new List<string>();

            foreach (var module in modules)
            {
                var methods = module
                    .GetMethods()
                    .Where(m => m.CustomAttributes.Any(attr => attr.AttributeType.Name == "CommandAttribute"))
                    .Where(m => m.GetCustomAttribute<CommandAttribute>()?.Command == command)
                    .Where(m => m.IsStatic)
                    .Where(m => m.ReturnType == typeof(string[]))
                    .SelectMany(m => (string[])(m.Invoke(null, new[] { args }) ?? "null return"));

                result.AddRange(methods);
            }

            return result;
        }

        public bool AddModule(Type module)
        {
            if (module.CustomAttributes.Any(attr => attr.AttributeType.Name == "ModuleAttribute"))
            {
                if (module.GetCustomAttribute<ModuleAttribute>()?.IsPrefixed ?? false)
                {
                    _prefixedModules.Add(module);
                }
                else
                {
                    _sysModules.Add(module);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}