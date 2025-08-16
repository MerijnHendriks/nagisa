using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Logical : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Logical(Expr left, Token op, Expr right) : base(EExpr.LOGICAL)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }
}