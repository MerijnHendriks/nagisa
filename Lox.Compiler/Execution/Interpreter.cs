using System;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Execution
{
    public sealed class Interpreter : IExpressionVisitor<object>
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
            return expression.Accept(this);
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
            if (left == null && right == null)
            {
                return true;
            }

            // second check to prevent NullRefEx in Equals
            if (left == null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public object VisitAssignExpression(Assign expression)
        {
            throw new NotImplementedException();
        }

        public object VisitBinaryExpression(Binary expression)
        {
            object left = this.Evaluate(expression.Left);
            object right = this.Evaluate(expression.Right); 

            switch (expression.Operator.Type)
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

        public object VisitCallExpression(Call expression)
        {
            throw new NotImplementedException();
        }

        public object VisitGetExpression(Get expression)
        {
            throw new NotImplementedException();
        }

        public object VisitGroupingExpression(Grouping expression)
        {
            return this.Evaluate(expression);
        }

        public object VisitLiteralExpression(Literal expression)
        {
            return expression.Value;
        }

        public object VisitLogicalExpression(Logical expression)
        {
            throw new NotImplementedException();
        }

        public object VisitSetExpression(Set expression)
        {
            throw new NotImplementedException();
        }

        public object VisitSuperExpression(Super expression)
        {
            throw new NotImplementedException();
        }

        public object VisitThisExpression(This expression)
        {
            throw new NotImplementedException();
        }

        public object VisitUnaryExpression(Unary expression)
        {
            object right = Evaluate(expression.Right);

            switch (expression.Operator.Type)
            {
                case TokenType.NOT:
                    return !this.IsTruthy(right);

                case TokenType.MINUS:
                    return -(double)right;
            }

            // Unreachable.
            return null;
        }

        public object VisitVariableExpression(Variable expression)
        {
            throw new NotImplementedException();
        }
    }
}