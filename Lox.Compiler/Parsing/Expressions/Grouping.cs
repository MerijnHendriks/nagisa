namespace Lox.Compiler.Parsing.Expressions
{
    public class Grouping : Expr
    {
        public Expr Expression;

        public Grouping(Expr expression)
        {
            Expression = expression;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitGroupingExpression(this);
        }
    }
}