using System.IO;
using Lox.Compiler.App.Common;

namespace Lox.Compiler.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new AppLogger();
            var compiler = new Compiler(logger);

            if (args.Length == 1)
            {
                Run(args, compiler);
                return;
            }

            if (args.Length > 1)
            {
                logger.WriteError("Cannot handle multiple files yet.");
                return;
            }

            // Handle no args
            logger.WriteInfo("");
            logger.WriteInfo("Usage: loxc [files]");
        }

        static void Run(string[] args, Compiler compiler)
        {
            var file = args[0];
            var source = File.ReadAllText(file);

            compiler.Run(file, source);
        }
    }
}