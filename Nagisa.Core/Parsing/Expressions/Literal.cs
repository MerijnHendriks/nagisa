using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Literal : Expr
    {
        public readonly Token Value;

        public Literal(Token value) : base(ExprType.LITERAL)
        {
            this.Value = value;
        }
    }
}