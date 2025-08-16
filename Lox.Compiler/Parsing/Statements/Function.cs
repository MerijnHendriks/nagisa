using System.Collections.Generic;
using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Statements
{
    public sealed class Function : Stmt
    {
        public readonly Token Name;
        public readonly List<Token> Parameters;
        public readonly List<Stmt> Body;

        public Function(Token name, List<Token> parameters, List<Stmt> body)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Body = body;
        }
    }
}