using System.Collections.Generic;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing.Statements
{
    public sealed class Class : Stmt
    {
        public readonly Token Name;
        public readonly Variable Superclass;
        public readonly List<Function> Methods;

        public Class(Token name, Variable superclass, List<Function> methods)
        {
            this.Name = name;
            this.Superclass = superclass;
            this.Methods = methods;
        }
    }
}