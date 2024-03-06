using System.Collections.Generic;
using System.IO;

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
                RunSingle(args, interpreter);
                return;
            }

            if (args.Length > 1)
            {
                RunMulti(args, interpreter);
                return;
            }

            // Handle no args
            logger.WriteInfo("");
            logger.WriteInfo("Usage: loxc [files]");
        }

        static void RunSingle(string[] args, Interpreter interpreter)
        {
            var file = args[0];
            var source = File.ReadAllText(file);

            interpreter.RunSingle(file, source);
        }

        static void RunMulti(string[] args, Interpreter interpreter)
        {
            var files = new string[args.Length];
            var sources = new string[args.Length];

            for (var i = 0; i < args.Length; ++i)
            {
                var file = args[i];
                var source = File.ReadAllText(file);

                files[i] = file;
                sources[i] = source;
            }

            interpreter.RunMulti(files, sources);
        }
    }
}