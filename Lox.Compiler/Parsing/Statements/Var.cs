using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public sealed class Var : Stmt
    {
        public readonly Token Name;
        public readonly Expr Initializer;

        public Var(Token name, Expr initializer)
        {
            this.Name = name;
            this.Initializer = initializer;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitVarStmt(this);
        }
    }
}