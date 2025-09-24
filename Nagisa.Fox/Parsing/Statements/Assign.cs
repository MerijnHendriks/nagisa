using Nagisa.Fox.Lexing;
using Nagisa.Fox.Parsing.Expressions;

namespace Nagisa.Fox.Parsing.Statements
{
    public sealed class Assign : Stmt
    {
        public readonly Variable Variable;
        public readonly Token Operator;
        public readonly Expr Value;

        public Assign(Variable variable, Token op, Expr value) : base(StmtType.ASSIGN)
        {
            this.Variable = variable;
            this.Operator = op;
            this.Value = value;
        }
    }
}