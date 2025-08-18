using System.Collections.Generic;
using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing.Statements
{
    public sealed class Function : Stmt
    {
        public readonly Token Name;
        public readonly List<Token> Parameters;
        public readonly List<Stmt> Body;

        public Function(Token name, List<Token> parameters, List<Stmt> body) : base(StmtType.FUNCTION)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Body = body;
        }
    }
}