// TODO: move this to VM bindings or standard library

using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
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