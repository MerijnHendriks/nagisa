using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Parsing.Statements
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