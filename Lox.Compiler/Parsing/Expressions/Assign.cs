using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Assign : Expr
    {
        public readonly Token Name;
        public readonly Expr Value;

        public Assign(Token name, Expr value) : base (EExpr.ASSIGN)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}