using Nagisa.Core;
using Nagisa.Lox.Lexing;

namespace Nagisa.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new AppLogger();
            var vfs = new AppVFS();

            var patterns = new LoxPatterns().Patterns;
            var compiler = new Compiler(logger, patterns);

            if (args.Length == 0)
            {
                logger.WriteInfo("");
                logger.WriteInfo("Usage: loxc [files]");
                return;
            }

            if (args.Length > 1)
            {
                logger.WriteError("Cannot handle multiple files yet.");
                return;
            }

            var file = args[0];
            var source = vfs.ReadTextFile(file);

            compiler.Run(file, source); 
        }
    }
}