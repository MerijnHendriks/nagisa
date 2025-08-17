namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Literal : Expr
    {
        public readonly object Value;

        public Literal(object value) : base(ExprType.LITERAL)
        {
            this.Value = value;
        }
    }
}