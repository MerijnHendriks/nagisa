namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Grouping : Expr
    {
        public readonly Expr Expression;

        public Grouping(Expr expression) : base(ExprType.GROUPING)
        {
            this.Expression = expression;
        }
    }
}