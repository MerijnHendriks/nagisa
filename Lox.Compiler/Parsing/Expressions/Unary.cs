using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Unary : Expr
    {
        public Token Operator;
        public Expr Right;

        public Unary(Token op, Expr right)
        {
            Operator = op;
            Right = right;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitUnaryExpression(this);
        }
    }
}