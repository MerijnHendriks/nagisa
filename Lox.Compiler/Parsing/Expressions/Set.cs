using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Set : Expr
    {
        public readonly Expr Object;
        public readonly Token Name;
        public readonly Expr Value;

        public Set(Expr obj, Token name, Expr value)
        {
            this.Object = obj;
            this.Name = name;
            this.Value = value;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitSetExpression(this);
        }
    }
}