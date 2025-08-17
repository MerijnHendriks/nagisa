using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
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