using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public sealed class Expression : Stmt
    {
        public readonly Expr Expr;

        public Expression(Expr expr)
        {
            this.Expr = expr;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitExpressionStmt(this);
        }
    }
}