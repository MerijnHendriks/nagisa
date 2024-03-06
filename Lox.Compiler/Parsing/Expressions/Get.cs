using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Get : Expr
    {
        public readonly Expr Object;
        public readonly Token Name;

        public Get(Expr obj, Token name)
        {
            this.Object = obj;
            this.Name = name;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitGetExpression(this);
        }
    }
}