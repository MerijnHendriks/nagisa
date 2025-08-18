using System;
using Nagisa.Core.Common;

namespace Nagisa.App
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