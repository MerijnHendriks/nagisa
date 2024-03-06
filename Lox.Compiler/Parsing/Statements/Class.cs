using System.Collections.Generic;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public class Class : Stmt
    {
        public Token Name;
        public Variable Superclass;
        public List<Function> Methods;

        public Class(Token name, Variable superclass, List<Function> methods)
        {
            Name = name;
            Superclass = superclass;
            Methods = methods;
        }

        public override T Accept<T>(IStatementVisitor<T> visitor)
        {
            return visitor.VisitClassStmt(this);
        }
    }
}