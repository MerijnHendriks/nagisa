using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Binary : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Binary(Expr left, Token op, Expr right) : base(EExpr.BINARY)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }
}