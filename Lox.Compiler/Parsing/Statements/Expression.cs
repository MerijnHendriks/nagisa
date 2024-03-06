using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class Expression : Stmt
    {
        public Expr Expr;

        public Expression(Expr expr)
        {
            Expr = expr;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitExpressionStmt(this);
        }
    }
}