using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class This : Expr
    {
        public Token Keyword;

        public This(Token keyword)
        {
            Keyword = keyword;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitThisExpression(this);
        }
    }
}