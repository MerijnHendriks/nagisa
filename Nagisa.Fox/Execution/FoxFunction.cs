using System.Collections.Generic;
using Nagisa.Fox.Parsing;

namespace Nagisa.Fox.Execution
{
    public class FoxFunction : FoxCallable
    {
        private readonly Fun _declaration;

        public FoxFunction(Fun declaration)
        {
            this._declaration = declaration;
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            Env env = new Env(interpreter.StdEnv);

            for (int i = 0; i < this._declaration.Parameters.Count; i += 1)
            {
                string identifier = this._declaration.Parameters[i].Value;
                env.Define(identifier, false, arguments[i]);
            }

            interpreter.ExecuteBlock(this._declaration.Body.Statements, env);
            return null;
        }

        public int Arity()
        {
            return this._declaration.Parameters.Count;
        }

        public override string ToString()
        {
            return "<fn " + this._declaration.Identifier.Value + ">";
        }
    }
}