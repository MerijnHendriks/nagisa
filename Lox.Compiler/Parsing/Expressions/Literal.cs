namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Literal : Expr
    {
        public readonly object Value;

        public Literal(object value)
        {
            this.Value = value;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitLiteralExpression(this);
        }
    }
}