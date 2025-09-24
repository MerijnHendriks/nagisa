using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Parsing.Expressions
{
    public sealed class Logical : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Logical(Expr left, Token op, Expr right) : base(ExprType.LOGICAL)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }
}