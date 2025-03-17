using System.IO;
using Lox.Compiler.App.Common;

namespace Lox.Compiler.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new AppLogger();
            var interpreter = new Interpreter(logger);

            if (args.Length == 1)
            {
                Run(args, interpreter);
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

        static void Run(string[] args, Interpreter interpreter)
        {
            var file = args[0];
            var source = File.ReadAllText(file);

            interpreter.Run(file, source);
        }
    }
}