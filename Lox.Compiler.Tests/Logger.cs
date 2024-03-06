using System;
using Lox.Compiler.Common;

namespace Lox.Compiler.Tests
{
    public class Logger : ILogger
    {
        public void WriteInfo(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteError(string text)
        {
            Console.WriteLine(text);
        }
    }
}