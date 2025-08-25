namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Literal : Expr
    {
        public readonly int ValueType;
        public readonly string Value;

        public Literal(int valueType, string value) : base(ExprType.LITERAL)
        {
            this.ValueType = valueType;
            this.Value = value;
        }
    }
}