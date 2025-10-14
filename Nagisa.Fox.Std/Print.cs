using System;
using System.Collections.Generic;
using Nagisa.Fox.Execution;

namespace Nagisa.Fox.Std
{
    public sealed class Print : FoxCallable
    {
        public object Call(Interpreter interpreter, List<object> arguments)
        {
            if (arguments.Count == 0 || arguments.Count > 1)
            {
                throw new InvalidOperationException("Argument count does not match.");
            }

            string value = arguments[0].ToString();

            // C# function
            Console.WriteLine(value);

            // void
            return null;
        }

        public int Arity()
        {
            return 1;
        }
    }
}