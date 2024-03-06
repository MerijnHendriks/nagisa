using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Get : Expr
    {
        public Expr Object;
        public Token Name;

        public Get(Expr obj, Token name)
        {
            Object = obj;
            Name = name;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitGetExpression(this);
        }
    }
}