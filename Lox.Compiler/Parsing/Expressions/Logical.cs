using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Logical : Expr
    {
        public Expr Left;
        public Token Operator;
        public Expr Right;

        public Logical(Expr left, Token op, Expr right)
        {
            Left = left;
            Operator = op;
            Right = right;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitLogicalExpression(this);
        }
    }
}