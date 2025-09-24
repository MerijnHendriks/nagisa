using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
{
    public sealed class While : Stmt
    {
        public readonly Expr Condition;
        public readonly Stmt Body;

        public While(Expr condition, Stmt body) : base(StmtType.WHILE)
        {
            this.Condition = condition;
            this.Body = body;
        }
    }
}