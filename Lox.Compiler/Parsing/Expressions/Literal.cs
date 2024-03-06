namespace Lox.Compiler.Parsing.Expressions
{
    public class Literal : Expr
    {
        public object Value;

        public Literal(object value)
        {
            Value = value;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitLiteralExpression(this);
        }
    }
}