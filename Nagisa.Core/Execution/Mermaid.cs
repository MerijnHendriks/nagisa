using System;
using System.Collections.Generic;
using System.Text;
using Nagisa.Core;
using Nagisa.Core.Common;
using Nagisa.Core.Parsing.Expressions;
using Nagisa.Core.Parsing.Statements;

namespace Nagisa.Core.Execution
{
    public sealed class Mermaid
    {
        private readonly Logger _logger;
        private readonly LanguageData _language;
        private readonly List<string> _nodes;
        private readonly List<string> _connections;
        private int _index;

        public Mermaid(Logger logger, LanguageData language)
        {
            this._logger = logger;
            this._language = language;
            this._nodes = new List<string>();
            this._connections = new List<string>();
            this._index = 0;
        }

        public string Generate(List<Stmt> statements)
        {
            string text = string.Empty;

            this.Execute(statements);
            text = this.ToMermaid();

            return text;
        }

        private string ToMermaid()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("```mermaid\n");
            sb.Append("flowchart TD\n");

            for (int i = 0; i < this._nodes.Count; i += 1)
            {
                sb.Append(this._nodes[i]);
            }

            for (int i = 0; i < this._connections.Count; i += 1)
            {
                sb.Append(this._connections[i]);
            }

            sb.Append("```");

            string text = sb.ToString();
            return text;
        }

        private int AddNode(string description)
        {
            string format = "    n{0}[{1}]\n";
            string text = string.Format(format, this._index, description);
            this._nodes.Add(text);

            this._index += 1;

            return this._index - 1;
        }

        private void AddConnection(int root, int child)
        {
            string format = "    n{0}--->n{1}\n";
            string text = string.Format(format, root, child);
            this._connections.Add(text);
        }

        public void Execute(List<Stmt> statements)
        {
            int root = 0;

            for (int i = 0; i < statements.Count; i += 1)
            {
                Stmt statement = statements[i];
                int child = this.EvaluateStatement(statement);

                if (root != 0)
                {
                    this.AddConnection(root, child);
                }

                root = child;
            }
        }

        // Statements

        private int EvaluateStatement(Stmt statement)
        {
            switch (statement.Type)
            {
                case StmtType.EXPRESSION:
                    return ExpressionStmt(statement);

                case StmtType.PRINT:
                    return PrintStmt(statement);
            }

            throw new InvalidOperationException("Statement not implemented.");
        }

        private int ExpressionStmt(Stmt statement)
        {
            Expression stmt = (Expression)statement;

            int child = this.EvaluateExpression(stmt.Expr);
            int root = this.AddNode("expression");

            this.AddConnection(root, child);

            return root;
        }

        private int PrintStmt(Stmt statement)
        {
            Print stmt = (Print)statement;

            int child = this.EvaluateExpression(stmt.Expr);
            int root = this.AddNode("print");

            this.AddConnection(root, child);

            return root;
        }

        // Expressions

        private int EvaluateExpression(Expr expression)
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

                default:
                    throw new InvalidOperationException("Expression not implemented.");
            }
        }

        private int BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            int left = this.EvaluateExpression(expr.Left);
            int right = this.EvaluateExpression(expr.Right);

            string name = this._language.GetTokenName(expr.Operator.Type);
            int root = this.AddNode("binary " + name);

            this.AddConnection(root, left);
            this.AddConnection(root, right);

            return root;
        }

        private int GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            int child = this.EvaluateExpression(expr.Expression);
            int root = this.AddNode("grouping");

            this.AddConnection(root, child);

            return root;
        }

        private int LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            string name = this._language.GetTokenName(expr.ValueType);
            string text = "literal " + name;

            if (!string.IsNullOrEmpty(expr.Value))
            {
                text += "\nvalue: " + expr.Value;
            }

            int root = this.AddNode(text);

            return root;
        }

        private int UnaryExpression(Expr expression)
        {
            Unary expr = (Unary)expression;

            int child = this.EvaluateExpression(expr.Right);

            string name = this._language.GetTokenName(expr.Operator.Type);
            int root = this.AddNode("unary " + name);

            this.AddConnection(root, child);

            return root;
        }
    }
}