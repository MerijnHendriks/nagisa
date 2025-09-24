using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
{
    public sealed class If : Stmt
    {
        public readonly Expr Condition;
        public readonly Stmt ThenBranch;
        public readonly Stmt ElseBranch;

        public If(Expr condition, Stmt thenBranch, Stmt elseBranch) : base(StmtType.IF)
        {
            this.Condition = condition;
            this.ThenBranch = thenBranch;
            this.ElseBranch = elseBranch;
        }
    }
}