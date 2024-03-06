using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Expressions
{
    public class Assign : Expr
    {
        public Token Name;
        public Expr Value;

        public Assign(Token name, Expr value)
        {
            Name = name;
            Value = value;
        }

        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.VisitAssignExpression(this);
        }
    }
}