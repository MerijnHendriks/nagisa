// TODO: move this to VM bindings or standard library

using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class Print : Stmt
    {
        public Expr Expression;

        public Print(Expr expression)
        {
            Expression = expression;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitPrintStmt(this);
        }
    }
}