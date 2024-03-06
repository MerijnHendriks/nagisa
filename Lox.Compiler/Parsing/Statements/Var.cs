using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class Var : Stmt
    {
        public Token Name;
        public Expr Initializer;

        public Var(Token name, Expr initializer)
        {
            Name = name;
            Initializer = initializer;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitVarStmt(this);
        }
    }
}