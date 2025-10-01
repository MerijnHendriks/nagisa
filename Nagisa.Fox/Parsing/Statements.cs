using System.Collections.Generic;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing
{
    public sealed class Assign : Stmt
    {
        public readonly Variable Variable;
        public readonly Token Operator;
        public readonly Expr Value;

        public Assign(Variable variable, Token op, Expr value) : base(StmtType.ASSIGN)
        {
            this.Variable = variable;
            this.Operator = op;
            this.Value = value;
        }
    }

    public sealed class Block : Stmt
    {
        public readonly List<Stmt> Statements;

        public Block(List<Stmt> statements) : base(StmtType.BLOCK)
        {
            this.Statements = statements;
        }
    }

    public sealed class Expression : Stmt
    {
        public readonly Expr Expr;

        public Expression(Expr expr) : base(StmtType.EXPRESSION)
        {
            this.Expr = expr;
        }
    }

    public sealed class Fun : Stmt
    {
        public readonly Token Identifier;
        public readonly List<Token> Parameters;
        public readonly Block Body;

        public Fun(Token identifier, List<Token> parameters, Block body) : base(StmtType.FUNCTION)
        {
            this.Identifier = identifier;
            this.Parameters = parameters;
            this.Body = body;
        }
    }

    public sealed class If : Stmt
    {
        public readonly Expr Condition;
        public readonly Block ThenBranch;
        public readonly Block ElseBranch;

        public If(Expr condition, Block thenBranch, Block elseBranch) : base(StmtType.IF)
        {
            this.Condition = condition;
            this.ThenBranch = thenBranch;
            this.ElseBranch = elseBranch;
        }
    }

    public sealed class Return : Stmt
    {
        public readonly Token Keyword;
        public readonly Expr Value;

        public Return(Token keyword, Expr value) : base(StmtType.RETURN)
        {
            this.Keyword = keyword;
            this.Value = value;
        }
    }

    public sealed class Var : Stmt
    {
        public readonly Variable Variable;
        public readonly Expr Value;

        public Var(Variable variable, Expr value) : base(StmtType.VAR)
        {
            this.Variable = variable;
            this.Value = value;
        }
    }

    public sealed class While : Stmt
    {
        public readonly Expr Condition;
        public readonly Block Body;

        public While(Expr condition, Block body) : base(StmtType.WHILE)
        {
            this.Condition = condition;
            this.Body = body;
        }
    }
}