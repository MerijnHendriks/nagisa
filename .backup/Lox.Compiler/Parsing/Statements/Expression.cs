using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
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