// TODO: move this to VM bindings or standard library

using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
{
    public sealed class Print : Stmt
    {
        public readonly Expr Expr;

        public Print(Expr expr) : base(StmtType.PRINT)
        {
            this.Expr = expr;
        }
    }
}