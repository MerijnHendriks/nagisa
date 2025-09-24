using System.Collections.Generic;
using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Parsing.Expressions
{
    public sealed class Call : Expr
    {
        public Expr Callee;
        public Token Paren;
        public List<Expr> Arguments;

        public Call(Expr callee, Token paren, List<Expr> arguments) : base(ExprType.CALL)
        {
            this.Callee = callee;
            this.Paren = paren;
            this.Arguments = arguments;
        }
    }
}