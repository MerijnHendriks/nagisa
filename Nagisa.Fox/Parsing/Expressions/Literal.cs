using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing.Expressions
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