using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class While : Stmt
    {
        public Expr Condition;
        public Stmt Body;

        public While(Expr condition, Stmt body)
        {
            Condition = condition;
            Body = body;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitWhileStmt(this);
        }
    }
}