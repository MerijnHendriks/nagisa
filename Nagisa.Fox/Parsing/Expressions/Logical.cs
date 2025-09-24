using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing.Expressions
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