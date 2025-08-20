namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Literal : Expr
    {
        public readonly int ValueType;
        public readonly object Value;

        public Literal(int valueType, object value) : base(ExprType.LITERAL)
        {
            this.ValueType = valueType;
            this.Value = value;
        }
    }
}