using System;
using System.Collections.Generic;
using Nagisa.Fox.Execution;

namespace Nagisa.Fox.Std
{
    public sealed class Print : FoxCallable
    {
        public object Call(Interpreter interpreter, List<object> arguments)
        {
            string value = (string)arguments[0];

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