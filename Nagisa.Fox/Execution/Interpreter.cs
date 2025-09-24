using System;
using System.Collections.Generic;
using System.Globalization;
using Nagisa.Fox.Common;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Parsing.Expressions;
using Nagisa.Fox.Parsing.Statements;

namespace Nagisa.Fox.Execution
{
    public sealed class Interpreter
    {
        private readonly Logger _logger;
        private readonly LanguageData _language;
        private Environment _environment;

        public Interpreter(Logger logger, LanguageData language)
        {
            this._logger = logger;
            this._language = language;
            this._environment = new Environment(null);
        }

        public void Execute(List<Stmt> statements)
        {
            for (int i = 0; i < statements.Count; i += 1)
            {
                Stmt statement = statements[i];

                this.EvaluateStatement(statement);
            }
        }

        // Statements

        private void EvaluateStatement(Stmt statement)
        {
            switch (statement.Type)
            {
                case StmtType.ASSIGN:
                    this.AssignStatement(statement);
                    return;

                case StmtType.BLOCK:
                    this.BlockStatement(statement);
                    return;

                case StmtType.EXPRESSION:
                    this.ExpressionStatement(statement);
                    return;

                case StmtType.IF:
                    this.IfStatement(statement);
                    return;

                case StmtType.PRINT:
                    this.PrintStatement(statement);
                    return;

                case StmtType.VAR:
                    VarStatement(statement);
                    return;
            }

            throw new InvalidOperationException("Statement not implemented.");
        }

        private void AssignStatement(Stmt statement)
        {
            Assign stmt = (Assign)statement;

            Expr expr;
            switch (stmt.Operator.Type)
            {
                case TokenType.ASSIGN:
                    expr = stmt.Value;
                    break;

                case TokenType.ADD_ASSIGN:
                    expr = new Binary(stmt.Variable, new Token(string.Empty, 0, 0, 0, TokenType.PLUS, string.Empty), stmt.Value);
                    break;

                case TokenType.SUBSTRACT_ASSIGN:
                    expr = new Binary(stmt.Variable, new Token(string.Empty, 0, 0, 0, TokenType.MINUS, string.Empty), stmt.Value);
                    break;

                case TokenType.MULTIPLY_ASSIGN:
                    expr = new Binary(stmt.Variable, new Token(string.Empty, 0, 0, 0, TokenType.STAR, string.Empty), stmt.Value);
                    break;

                case TokenType.DIVIDE_ASSIGN:
                    expr = new Binary(stmt.Variable, new Token(string.Empty, 0, 0, 0, TokenType.SLASH, string.Empty), stmt.Value);
                    break;

                default:
                    throw new InvalidOperationException("Assignment not implemented: " + stmt.Operator.Type);
            }

            object value = this.EvaluateExpression(expr);
            this._environment.Set(stmt.Variable.Identifier.Value, value);
        }

        private void BlockStatement(Stmt statement)
        {
            Block stmt = (Block)statement;

            this.ExecuteBlock(stmt.Statements, new Environment(this._environment));
        }

        private void ExpressionStatement(Stmt statement)
        {
            Expression stmt = (Expression)statement;

            this.EvaluateExpression(stmt.Expr);
        }

        private void IfStatement(Stmt statement)
        {
            If stmt = (If)statement;

            object result = this.EvaluateExpression(stmt.Condition);

            if (this.IsTruthy(result))
            {
                this.EvaluateStatement(stmt.ThenBranch);
            }
            else
            {
                if (stmt.ElseBranch != null)
                {
                    this.EvaluateStatement(stmt.ElseBranch);
                }
            }
        }

        private void PrintStatement(Stmt statement)
        {
            Print stmt = (Print)statement;

            object value = this.EvaluateExpression(stmt.Expr);
            string text = this.Stringify(value);

            this._logger.Write(text);
        }

        private void VarStatement(Stmt statement)
        {
            Var stmt = (Var)statement;

            object value = this.EvaluateExpression(stmt.Value);

            this._environment.Define(stmt.Variable.Identifier.Value, true, value);
        }

        private void ExecuteBlock(List<Stmt> statements, Environment environment)
        {
            Environment previous = this._environment;

            // run in enclosed scope
            this._environment = environment;
            this.Execute(statements);

            // restore scope
            this._environment = previous;
        }

        // Expressions

        private object EvaluateExpression(Expr expression)
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

                case ExprType.VARIABLE:
                    return this.VariableExpression(expression);
            }

            throw new InvalidOperationException("Expression not implemented.");
        }

        private object BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            object left = this.EvaluateExpression(expr.Left);
            object right = this.EvaluateExpression(expr.Right);

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

            return this.EvaluateExpression(expr.Expression);
        }

        private object LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            switch (expr.Value.Type)
            {
                case TokenType.NUMBER:
                    return Convert.ToDouble(expr.Value.Value, CultureInfo.InvariantCulture);

                case TokenType.STRING:
                    return expr.Value.Value;

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

            object right = this.EvaluateExpression(expr.Right);

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

        private object VariableExpression(Expr expression)
        {
            Variable expr = (Variable)expression;

            return this._environment.Get(expr.Identifier.Value);
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
    }
}