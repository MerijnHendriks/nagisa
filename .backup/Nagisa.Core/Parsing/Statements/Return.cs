using Nagisa.Fox.Lexing;
using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
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