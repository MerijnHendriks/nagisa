using System.Collections.Generic;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing
{
    public sealed class Binary : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Binary(Expr left, Token op, Expr right) : base(ExprType.BINARY)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }

    public sealed class Grouping : Expr
    {
        public readonly Expr Expression;

        public Grouping(Expr expression) : base(ExprType.GROUPING)
        {
            this.Expression = expression;
        }
    }

    public sealed class Call : Expr
    {
        public Expr Callee;
        public List<Expr> Arguments;

        public Call(Expr callee, List<Expr> arguments) : base(ExprType.CALL)
        {
            this.Callee = callee;
            this.Arguments = arguments;
        }
    }

    public sealed class Literal : Expr
    {
        public readonly Token Value;

        public Literal(Token value) : base(ExprType.LITERAL)
        {
            this.Value = value;
        }
    }

    public sealed class Logical : Expr
    {
        public readonly Expr Left;
        public readonly Token Operator;
        public readonly Expr Right;

        public Logical(Expr left, Token op, Expr right) : base(ExprType.LOGICAL)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }

    public sealed class Unary : Expr
    {
        public readonly Token Operator;
        public readonly Expr Right;

        public Unary(Token op, Expr right) : base(ExprType.UNARY)
        {
            this.Operator = op;
            this.Right = right;
        }
    }

    public sealed class Variable : Expr
    {
        public readonly Token Identifier;

        public Variable(Token identifier) : base(ExprType.VARIABLE)
        {
            this.Identifier = identifier;
        }
    }
}