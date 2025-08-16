using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public sealed class Get : Expr
    {
        public readonly Expr Object;
        public readonly Token Name;

        public Get(Expr obj, Token name) : base(EExpr.GET)
        {
            this.Object = obj;
            this.Name = name;
        }
    }
}