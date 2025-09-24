using System;
using Nagisa.Fox.Common;

namespace Nagisa.Fox.Tests.Common
{
    public sealed class TestLogger : Logger
    {
        private const string INFO_FORMAT = "[INFO] {0}";
        private const string ERROR_FORMAT = "[ERROR] {0}";

        public override void Write(string text)
        {
            Console.WriteLine(text);
        }

        public override void WriteInfo(string text)
        {
            string message = string.Format(INFO_FORMAT, text);

            Console.WriteLine(message);
        }

        public override void WriteError(string text)
        {
            string message = string.Format(ERROR_FORMAT, text);

            Console.WriteLine(message);
        }
    }
}