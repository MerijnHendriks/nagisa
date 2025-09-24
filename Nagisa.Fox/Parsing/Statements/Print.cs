// TODO: move this to VM bindings or standard library

using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
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