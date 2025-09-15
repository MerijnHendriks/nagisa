using System;
using System.Globalization;
using Nagisa.Core.Common;
using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Execution
{
    public sealed class Interpreter
    {
        private readonly Logger _logger;
        private readonly LanguageData _language;

        public Interpreter(Logger logger, LanguageData language)
        {
            this._logger = logger;
            this._language = language;
        }

        public string Interpret(Expr expr)
        {
            object value = this.Evaluate(expr);
            string text = this.Stringify(value);

            return text;
        }

        private object Evaluate(Expr expression)
        {
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
            }

            throw new InvalidOperationException("Expression not implemented.");
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

        private void CheckNumberOperand(Token op, object operand)
        {
            if (operand.GetType() == typeof(double))
            {
                return;
            }

            string name = this._language.GetTokenName(op.Type);
            string format = "{0} operand must be a number.";
            string message = string.Format(format, name);

            throw new InvalidOperationException(message);
        }

        private void CheckNumberOperands(Token op, object left, object right)
        {
            if (left.GetType() == typeof(double) && right.GetType() == typeof(double))
            {
                return;
            }

            string name = this._language.GetTokenName(op.Type);
            string format = "{0} operands must be numbers.";
            string message = string.Format(format, name);

            throw new InvalidOperationException(message);
        }

        private object BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            object left = this.Evaluate(expr.Left);
            object right = this.Evaluate(expr.Right); 

            switch (expr.Operator.Type)
            {
                case TokenType.RIGHT_ARROW:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left > (double)right;

                case TokenType.GREATER_EQUAL:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left >= (double)right;

                case TokenType.LEFT_ARROW:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left < (double)right;

                case TokenType.LESS_EQUAL:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left <= (double)right;

                case TokenType.MINUS:
                    this.CheckNumberOperands(expr.Operator, left, right);
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

                    throw new InvalidOperationException(expr.Operator + " operands must be two numbers or two strings.");

                case TokenType.SLASH:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left / (double)right;
            
                case TokenType.STAR:
                    this.CheckNumberOperands(expr.Operator, left, right);
                    return (double)left * (double)right;

                case TokenType.NOT_EQUAL:
                    return !this.IsEqual(left, right);

                case TokenType.EQUAL:
                    return this.IsEqual(left, right);
            }

            // Unreachable.
            return null;
        }

        private object GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            return this.Evaluate(expr.Expression);
        }

        private object LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            switch (expr.ValueType)
            {
                case TokenType.NUMBER:
                    return Convert.ToDouble(expr.Value, CultureInfo.InvariantCulture);

                case TokenType.STRING:
                    return expr.Value;

                case TokenType.FALSE:
                    return false;

                case TokenType.TRUE:
                    return true;

                case TokenType.NIL:
                    return null;
            }

            throw new InvalidOperationException("Unreachable - Literal.");
        }

        private object UnaryExpression(Expr expression)
        {
            Unary expr = (Unary)expression;

            object right = this.Evaluate(expr.Right);

            switch (expr.Operator.Type)
            {
                case TokenType.NOT:
                    return !this.IsTruthy(right);

                case TokenType.MINUS:
                    this.CheckNumberOperand(expr.Operator, right);
                    return -(double)right;
            }

            throw new InvalidOperationException("Unreachable - Unary.");
        }
    }
}