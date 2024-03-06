using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class Return : Stmt
    {
        public Token Keyword;
        public Expr Value;

        public Return(Token keyword, Expr value)
        {
            Keyword = keyword;
            Value = value;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitReturnStmt(this);
        }
    }
}