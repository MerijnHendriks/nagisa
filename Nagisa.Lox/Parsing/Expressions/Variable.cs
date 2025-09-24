using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Parsing.Expressions
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