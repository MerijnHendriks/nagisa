using System;
using System.Collections.Generic;
using System.Text;
using Nagisa.Core.Common;
using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing.Expressions;

namespace Nagisa.Core.Execution
{
    public sealed class MermaidGenerator
    {
        private readonly Logger _logger;
        private readonly List<string> _nodes;
        private readonly List<string> _connections;
        private int _index;

        public MermaidGenerator(Logger logger)
        {
            this._logger = logger;
            this._nodes = new List<string>();
            this._connections = new List<string>();
            _index = 0;
        }

        public int AddNode(string description)
        {
            string format = "    n{0}[{1}]\n";
            string text = string.Format(format, this._index, description);
            this._nodes.Add(text);

            this._index += 1;

            return this._index - 1;
        }

        public void AddConnection(int root, int child)
        {
            string format = "    n{0}--->n{1}\n";
            string text = string.Format(format, root, child);
            this._connections.Add(text);
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

        public int BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            int left = this.Evaluate(expr.Left);
            int right = this.Evaluate(expr.Right);
            int root = this.AddNode("expr binary");

            this.AddConnection(root, left);
            this.AddConnection(root, right);

            return root;
        }

        public int GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            int child = this.Evaluate(expr.Expression);
            int root = this.AddNode("expr grouping");

            this.AddConnection(root, child);

            return root;
        }

        public int LiteralExpression(Expr expression)
        {
            int root = this.AddNode("expr literal");

            return root;
        }

        public int UnaryExpression(Expr expression)
        {
            Unary expr = (Unary)expression;

            int child = this.Evaluate(expr.Right);
            int root = this.AddNode("expr unary");

            this.AddConnection(root, child);

            return root;
        }
    }
}