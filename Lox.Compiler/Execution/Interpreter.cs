using System;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Execution
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
                case ExprType.ASSIGN:
                    return this.VisitAssignExpression((Assign)expression);

                case ExprType.BINARY:
                    return this.VisitBinaryExpression((Binary)expression);

                case ExprType.CALL:
                    return this.VisitCallExpression((Call)expression);

                case ExprType.GET:
                    return this.VisitGetExpression((Get)expression);

                case ExprType.GROUPING:
                    return this.VisitGroupingExpression((Grouping)expression);

                case ExprType.LITERAL:
                    return this.VisitLiteralExpression((Literal)expression);

                case ExprType.LOGICAL:
                    return this.VisitLogicalExpression((Logical)expression);

                case ExprType.SET:
                    return this.VisitSetExpression((Set)expression);

                case ExprType.SUPER:
                    return this.VisitSuperExpression((Super)expression);

                case ExprType.THIS:
                    return this.VisitThisExpression((This)expression);

                case ExprType.UNARY:
                    return this.VisitUnaryExpression((Unary)expression);

                case ExprType.VARIABLE:
                    return this.VisitVariablExprTypeession((Variable)expression);

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
            object right = this.Evaluate(expression.Right);

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

        public object VisitVariablExprTypeession(Variable expression)
        {
            throw new NotImplementedException();
        }
    }
}