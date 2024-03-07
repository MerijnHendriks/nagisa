using System;
using Lox.Compiler.Common;

namespace Lox.Compiler.Tests.Common
{
    public sealed class TestLogger : Logger
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