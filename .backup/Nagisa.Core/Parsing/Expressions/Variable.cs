using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Variable : Expr
    {
        public readonly Token Name;

        public Variable(Token name) : base(ExprType.VARIABLE)
        {
            this.Name = name;
        }
    }
}