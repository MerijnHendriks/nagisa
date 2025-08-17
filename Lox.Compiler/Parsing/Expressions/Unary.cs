using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Unary : Expr
    {
        public readonly Token Operator;
        public readonly Expr Right;

        public Unary(Token op, Expr right) : base(ExprType.UNARY)
        {
            this.Operator = op;
            this.Right = right;
        }
    }
}