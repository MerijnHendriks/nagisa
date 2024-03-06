using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Set : Expr
    {
        public Expr Object;
        public Token Name;
        public Expr Value;

        public Set(Expr obj, Token name, Expr value)
        {
            Object = obj;
            Name = name;
            Value = value;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitSetExpression(this);
        }
    }
}