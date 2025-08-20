using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Parsing.Statements
{
    public sealed class Expression : Stmt
    {
        public readonly Expr Expr;

        public Expression(Expr expr) : base(StmtType.EXPRESSION)
        {
            this.Expr = expr;
        }
    }
}