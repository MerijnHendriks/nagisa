using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
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