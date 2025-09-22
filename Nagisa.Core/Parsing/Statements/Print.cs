// TODO: move this to VM bindings or standard library

using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Parsing.Statements
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