using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Parsing.Expressions
{
    public sealed class Get : Expr
    {
        public readonly Expr Object;
        public readonly Token Name;

        public Get(Expr obj, Token name) : base(ExprType.GET)
        {
            this.Object = obj;
            this.Name = name;
        }
    }
}