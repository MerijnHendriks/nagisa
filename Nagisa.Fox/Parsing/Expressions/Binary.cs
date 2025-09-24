using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing.Expressions
{
    public sealed class Binary : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Binary(Expr left, Token op, Expr right) : base(ExprType.BINARY)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }
}