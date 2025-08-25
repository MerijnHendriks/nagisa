using System;
using System.Collections.Generic;
using System.Text;
using Nagisa.Core.Common;
using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Execution
{
    public sealed class Mermaid
    {
        private readonly Logger _logger;
        private readonly List<string> _nodes;
        private readonly List<string> _connections;
        private int _index;

        public Mermaid(Logger logger)
        {
            this._logger = logger;
            this._nodes = new List<string>();
            this._connections = new List<string>();
            _index = 0;
        }

        public string Generate(Expr expr)
        {
            this.Evaluate(expr);

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

        private int Evaluate(Expr expression)
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

            int left = this.Evaluate(expr.Left);
            int right = this.Evaluate(expr.Right);
            int root = this.AddNode("binary " + expr.Operator.Type);

            this.AddConnection(root, left);
            this.AddConnection(root, right);

            return root;
        }

        private int GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            int child = this.Evaluate(expr.Expression);
            int root = this.AddNode("grouping");

            this.AddConnection(root, child);

            return root;
        }

        private int LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            string text = "literal " + expr.ValueType;

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

            int child = this.Evaluate(expr.Right);
            int root = this.AddNode("unary " + expr.Operator.Type);

            this.AddConnection(root, child);

            return root;
        }
    }
}