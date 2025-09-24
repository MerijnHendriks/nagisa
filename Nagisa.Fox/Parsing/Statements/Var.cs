using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
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