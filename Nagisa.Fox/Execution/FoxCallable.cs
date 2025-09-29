using System.Collections.Generic;

namespace Nagisa.Fox.Execution
{
    public interface FoxCallable
    {
        object Call(Interpreter interpreter, List<object> arguments);
        int Arity();
    }
}