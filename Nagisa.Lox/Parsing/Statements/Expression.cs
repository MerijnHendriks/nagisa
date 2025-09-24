using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
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