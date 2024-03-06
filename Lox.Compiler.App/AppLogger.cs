using System;
using Lox.Compiler.Common;

namespace Lox.Compiler.App
{
    public sealed class AppLogger : Logger
    {
        public override void WriteInfo(string text)
        {
            Console.WriteLine(text);
        }

        public override void WriteError(string text)
        {
            Console.WriteLine(text);
        }
    }
}