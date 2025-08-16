using System.Collections.Generic;

namespace Lox.Compiler.Parsing.Statements
{
    public sealed class Block : Stmt
    {
        public readonly List<Stmt> Statements;

        public Block(List<Stmt> statements)
        {
            this.Statements = statements;
        }
    }
}