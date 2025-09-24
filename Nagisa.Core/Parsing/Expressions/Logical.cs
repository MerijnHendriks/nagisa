using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
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