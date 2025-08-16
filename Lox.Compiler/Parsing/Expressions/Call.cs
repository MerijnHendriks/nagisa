using System.Collections.Generic;
using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Call : Expr
    {
        public Expr Callee;
        public Token Paren;
        public List<Expr> Arguments;

        public Call(Expr callee, Token paren, List<Expr> arguments) : base(EExpr.CALL)
        {
            this.Callee = callee;
            this.Paren = paren;
            this.Arguments = arguments;
        }
    }
}