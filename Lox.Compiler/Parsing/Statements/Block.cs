using System.Collections.Generic;

namespace Lox.Compiler.Parsing.Statements
{
    public class Block : Stmt
    {
        public List<Stmt> Statements;

        public Block(List<Stmt> statements)
        {
            Statements = statements;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitBlockStmt(this);
        }
    }
}