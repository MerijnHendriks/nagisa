using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class This : Expr
    {
        public readonly Token Keyword;

        public This(Token keyword)
        {
            this.Keyword = keyword;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitThisExpression(this);
        }
    }
}