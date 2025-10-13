using Nagisa.Fox.Execution;

namespace Nagisa.Fox.Std
{
    public sealed class StdEnv : Env
    {
        public StdEnv() : base(null)
        {
            this.Define("print", false, new Print());
        }
    }
}