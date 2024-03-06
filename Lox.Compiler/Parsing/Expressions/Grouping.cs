namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Grouping : Expr
    {
        public readonly Expr Expression;

        public Grouping(Expr expression)
        {
            this.Expression = expression;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitGroupingExpression(this);
        }
    }
}