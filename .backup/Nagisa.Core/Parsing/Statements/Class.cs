using System.Collections.Generic;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Parsing.Expressions;

namespace Nagisa.Lox.Parsing.Statements
{
    public sealed class Class : Stmt
    {
        public readonly Token Name;
        public readonly Variable Superclass;
        public readonly List<Function> Methods;

        public Class(Token name, Variable superclass, List<Function> methods) : base(StmtType.CLASS)
        {
            this.Name = name;
            this.Superclass = superclass;
            this.Methods = methods;
        }
    }
}