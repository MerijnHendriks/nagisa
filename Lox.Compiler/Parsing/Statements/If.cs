using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class If : Stmt
    {
        public Expr Condition;
        public Stmt ThenBranch;
        public Stmt ElseBranch;

        public If(Expr condition, Stmt thenBranch, Stmt elseBranch)
        {
            Condition = condition;
            ThenBranch = thenBranch;
            ElseBranch = elseBranch;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitIfStmt(this);
        }
    }
}