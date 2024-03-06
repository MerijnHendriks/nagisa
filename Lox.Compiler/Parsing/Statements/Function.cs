using System.Collections.Generic;
using Lox.Compiler.Lexing;

namespace Lox.Compiler.Parsing.Statements
{
    public class Function : Stmt
    {
        public Token Name;
        public List<Token> Parameters;
        public List<Stmt> Body;

        public Function(Token name, List<Token> parameters, List<Stmt> body)
        {
            Name = name;
            Parameters = parameters;
            Body = body;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitFunctionStmt(this);
        }
    }
}