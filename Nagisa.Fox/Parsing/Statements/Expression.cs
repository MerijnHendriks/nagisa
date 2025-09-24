using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
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