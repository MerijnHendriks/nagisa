using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Expressions
{
    public sealed class Set : Expr
    {
        public readonly Expr Object;
        public readonly Token Name;
        public readonly Expr Value;

        public Set(Expr obj, Token name, Expr value) : base(ExprType.SET)
        {
            this.Object = obj;
            this.Name = name;
            this.Value = value;
        }
    }
}