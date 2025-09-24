using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing.Expressions
{
    public sealed class Variable : Expr
    {
        public readonly Token Identifier;

        public Variable(Token identifier) : base(ExprType.VARIABLE)
        {
            this.Identifier = identifier;
        }
    }
}