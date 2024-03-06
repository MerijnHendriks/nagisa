using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Super : Expr
    {
        public readonly Token Keyword;
        public readonly Token Method;

        public Super(Token keyword, Token method)
        {
            this.Keyword = keyword;
            this.Method = method;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitSuperExpression(this);
        }
    }
}