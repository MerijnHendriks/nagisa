namespace Lox.Compiler.Parsing.Expressions
{
    public abstract class Expr
    {
        public abstract T Accept<T>(IExpressionVisitor<T> visitor);
    }
}