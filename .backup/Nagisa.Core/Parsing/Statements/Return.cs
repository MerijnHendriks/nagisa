using Nagisa.Lox.Lexing;
using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
{
    public sealed class Return : Stmt
    {
        public readonly Token Keyword;
        public readonly Expr Value;

        public Return(Token keyword, Expr value) : base(StmtType.RETURN)
        {
            this.Keyword = keyword;
            this.Value = value;
        }
    }
}