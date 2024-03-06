using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Super : Expr
    {
        public Token Keyword;
        public Token Method;

        public Super(Token keyword, Token method)
        {
            Keyword = keyword;
            Method = method;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitSuperExpression(this);
        }
    }
}