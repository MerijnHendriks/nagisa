using System;
using Nagisa.Core.Common;

namespace Nagisa.Lox.Tests.Common
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