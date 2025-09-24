using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
{
    public sealed class Var : Stmt
    {
        public readonly Variable Variable;
        public readonly Expr Value;

        public Var(Variable variable, Expr value) : base(StmtType.VAR)
        {
            this.Variable = variable;
            this.Value = value;
        }
    }
}