using System.Collections.Generic;

namespace Nagisa.Core.Parsing.Statements
{
    public sealed class Block : Stmt
    {
        public readonly List<Stmt> Statements;

        public Block(List<Stmt> statements) : base(StmtType.BLOCK)
        {
            this.Statements = statements;
        }
    }
}