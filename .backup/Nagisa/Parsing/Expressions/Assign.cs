using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Assign : Expr
    {
        public readonly Token Name;
        public readonly Expr Value;

        public Assign(Token name, Expr value) : base (ExprType.ASSIGN)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}