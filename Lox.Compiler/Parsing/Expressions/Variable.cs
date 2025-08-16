using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Variable : Expr
    {
        public readonly Token Name;

        public Variable(Token name) : base(EExpr.VARIABLE)
        {
            this.Name = name;
        }
    }
}