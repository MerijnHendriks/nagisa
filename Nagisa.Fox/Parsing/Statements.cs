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

    public sealed class If : Stmt
    {
        public readonly Expr Condition;
        public readonly Stmt ThenBranch;
        public readonly Stmt ElseBranch;

        public If(Expr condition, Stmt thenBranch, Stmt elseBranch) : base(StmtType.IF)
        {
            this.Condition = condition;
            this.ThenBranch = thenBranch;
            this.ElseBranch = elseBranch;
        }
    }

    // TODO: move this to VM bindings or standard library
    public sealed class Print : Stmt
    {
        public readonly Expr Expr;

        public Print(Expr expr) : base(StmtType.PRINT)
        {
            this.Expr = expr;
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
        public readonly Stmt Body;

        public While(Expr condition, Stmt body) : base(StmtType.WHILE)
        {
            this.Condition = condition;
            this.Body = body;
        }
    }
}