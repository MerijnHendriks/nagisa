using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing.Expressions
{
    public sealed class This : Expr
    {
        public readonly Token Keyword;

        public This(Token keyword) : base(ExprType.THIS)
        {
            this.Keyword = keyword;
        }
    }
}