using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Super : Expr
    {
        public readonly Token Keyword;
        public readonly Token Method;

        public Super(Token keyword, Token method) : base(ExprType.SUPER)
        {
            this.Keyword = keyword;
            this.Method = method;
        }
    }
}