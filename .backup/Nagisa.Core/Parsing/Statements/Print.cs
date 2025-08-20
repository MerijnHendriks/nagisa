// TODO: move this to VM bindings or standard library

using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Parsing.Statements
{
    public sealed class Print : Stmt
    {
        public readonly Expr Expression;

        public Print(Expr expression) : base(StmtType.PRINT)
        {
            this.Expression = expression;
        }
    }
}