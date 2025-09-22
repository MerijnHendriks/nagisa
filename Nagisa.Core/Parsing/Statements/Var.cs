using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Parsing.Statements
{
    public sealed class Var : Stmt
    {
        public readonly Token Identifier;
        public readonly Expr Expr;

        public Var(Token identifier, Expr expr) : base(StmtType.VAR)
        {
            this.Identifier = identifier;
            this.Expr = expr;
        }
    }
}