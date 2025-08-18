using System;
using Nagisa.Core.Common;
using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Execution
{
    public sealed class Interpreter
    {
        private readonly Logger _logger;

        public Interpreter(Logger logger)
        {
            this._logger = logger;
        }

        public void Interpret(Expr expr)
        {
            object value = this.Evaluate(expr);
            string text = this.Stringify(value);
            this._logger.WriteInfo(text);
        }

        private object Evaluate(Expr expression)
        {
            this._logger.WriteInfo("[EVAL] type: " + expression.Type);

            switch (expression.Type)
            {
                case ExprType.BINARY:
                    return this.BinaryExpression(expression);

                case ExprType.GROUPING:
                    return this.GroupingExpression(expression);

                case ExprType.LITERAL:
                    return this.LiteralExpression(expression);

                case ExprType.UNARY:
                    return this.UnaryExpression(expression);

                default:
                    throw new InvalidOperationException("Expression not implemented.");
            }
        }

        private string Stringify(object o)
        {
            if (o == null)
            {
                return "nil";
            }

            return o.ToString();
        }

        private bool IsTruthy(object o)
        {
            if (o == null)
            {
                return false;
            }

            if (o.GetType() == typeof(bool))
            {
                return (bool)o;
            }

            return true;
        }

        private bool IsEqual(object left, object right)
        {
            // If both are null, they are equal
            if (left == null && right == null)
            {
                return true;
            }

            // Second null check to prevent NullRefEx in type Equals
            if (left == null)
            {
                return false;
            }

            // Handle equality by type
            return left.Equals(right);
        }

        public object BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            object left = this.Evaluate(expr.Left);
            object right = this.Evaluate(expr.Right); 

            switch (expr.Operator.Type)
            {
                case TokenType.RIGHT_ARROW:
                    return (double)left > (double)right;

                case TokenType.GREATER_EQUAL:
                    return (double)left >= (double)right;

                case TokenType.LEFT_ARROW:
                    return (double)left < (double)right;

                case TokenType.LESS_EQUAL:
                    return (double)left <= (double)right;

                case TokenType.MINUS:
                    return (double)left - (double)right;

                case TokenType.PLUS:
                    if (left.GetType() == typeof(double) && right.GetType() == typeof(double))
                    {
                        return (double)left + (double)right;
                    }

                    // concat strings
                    if (left.GetType() == typeof(string) && right.GetType() == typeof(string))
                    {
                        return (string)left + (string)right;
                    }
                    break;

                case TokenType.SLASH:
                    return (double)left / (double)right;
            
                case TokenType.STAR:
                    return (double)left * (double)right;

                case TokenType.NOT_EQUAL:
                    return !this.IsEqual(left, right);

                case TokenType.EQUAL:
                    return this.IsEqual(left, right);
            }

            // Unreachable.
            return null;
        }

        public object GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            return this.Evaluate(expression);
        }

        public object LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            return expr.Value;
        }

        public object UnaryExpression(Expr expression)
        {
            Unary expr = (Unary)expression;

            object right = this.Evaluate(expr.Right);

            switch (expr.Operator.Type)
            {
                case TokenType.NOT:
                    return !this.IsTruthy(right);

                case TokenType.MINUS:
                    return -(double)right;
            }

            // Unreachable.
            throw new InvalidOperationException("How?");
        }
    }
}