namespace Lox.Compiler.Parsing.Statements
{
    public abstract class Stmt
    {
        public abstract T Accept<T>(IStatementVisitor<T> visitor);
    }
}