using System;
using System.Collections.Generic;
using System.Text;
using Nagisa.Fox;
using Nagisa.Fox.Parsing;

namespace Nagisa.Fox.Execution
{
    public sealed class Mermaid
    {
        private readonly LanguageData _language;
        private readonly List<string> _nodes;
        private readonly List<string> _connections;
        private int _index;

        public Mermaid(LanguageData language)
        {
            this._language = language;
            this._nodes = new List<string>();
            this._connections = new List<string>();
            this._index = 0;
        }

        public string Generate(List<Stmt> statements)
        {
            string text = string.Empty;

            this.Execute(statements, 0);
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

        private void AddDottedConnection(int root, int child)
        {
            string format = "    n{0}-.->n{1}\n";
            string text = string.Format(format, root, child);
            this._connections.Add(text);
        }

        private void AddLineConnection(int root, int child)
        {
            string format = "    n{0}--->n{1}\n";
            string text = string.Format(format, root, child);
            this._connections.Add(text);
        }

        public int Execute(List<Stmt> statements, int root)
        {
            for (int i = 0; i < statements.Count; i += 1)
            {
                Stmt statement = statements[i];
                int child = this.EvaluateStatement(statement);

                if (root != 0)
                {
                    this.AddLineConnection(root, child);
                }

                root = child;
            }

            return root;
        }

        // Statements

        private int EvaluateStatement(Stmt statement)
        {
            switch (statement.Type)
            {
                case StmtType.ASSIGN:
                    return this.AssignStatement(statement);

                case StmtType.BLOCK:
                    return this.BlockStatement(statement);

                case StmtType.EXPRESSION:
                    return this.ExpressionStatement(statement);

                case StmtType.IF:
                    return this.IfStatement(statement);

                case StmtType.VAR:
                    return this.VarStatement(statement);

                case StmtType.WHILE:
                    return this.WhileStatement(statement);
            }

            throw new InvalidOperationException("Statement not implemented.");
        }

        private int AssignStatement(Stmt statement)
        {
            Assign stmt = (Assign)statement;

            string name = this._language.GetTokenName(stmt.Operator.Type);
            string text = "assign " + name;

            int left = this.EvaluateExpression(stmt.Variable);
            int right = this.EvaluateExpression(stmt.Value);
            int root = this.AddNode(text);

            this.AddDottedConnection(root, left);
            this.AddDottedConnection(root, right);

            return root;
        }

        // TODO: fix!
        private int BlockStatement(Stmt statement)
        {
            Block stmt = (Block)statement;

            int root = this.AddNode("block");

            this.Execute(stmt.Statements, root);

            return root;
        }

        private int ExpressionStatement(Stmt statement)
        {
            Expression stmt = (Expression)statement;

            int child = this.EvaluateExpression(stmt.Expr);
            int root = this.AddNode("expression");

            this.AddDottedConnection(root, child);

            return root;
        }

        private int IfStatement(Stmt statement)
        {
            If stmt = (If)statement;

            int condition = this.EvaluateExpression(stmt.Condition);
            int left = this.EvaluateStatement(stmt.ThenBranch);
            int right = this.EvaluateStatement(stmt.ElseBranch);
            int root = this.AddNode("if");

            this.AddDottedConnection(root, condition);
            this.AddLineConnection(root, left);
            this.AddLineConnection(root, right);

            return root;
        }

        private int VarStatement(Stmt statement)
        {
            Var stmt = (Var)statement;

            int left = this.EvaluateExpression(stmt.Variable);
            int right = this.EvaluateExpression(stmt.Value);
            int root = this.AddNode("var");

            this.AddDottedConnection(root, left);
            this.AddDottedConnection(root, right);

            return root;
        }

        private int WhileStatement(Stmt statement)
        {
            While stmt = (While)statement;

            int condition = this.EvaluateExpression(stmt.Condition);
            int body = this.EvaluateStatement(stmt.Body);
            int root = this.AddNode("while");

            this.AddDottedConnection(root, condition);
            this.AddLineConnection(root, body);

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

                case ExprType.LOGICAL:
                    return this.LogicalExpression(expression);

                case ExprType.UNARY:
                    return this.UnaryExpression(expression);

                case ExprType.VARIABLE:
                    return this.VariableExpression(expression);

                case ExprType.CALL:
                    return this.CallExpression(expression);
            }

            throw new InvalidOperationException("Expression " + expression.Type + " not implemented.");
        }

        private int BinaryExpression(Expr expression)
        {
            Binary expr = (Binary)expression;

            int left = this.EvaluateExpression(expr.Left);
            int right = this.EvaluateExpression(expr.Right);

            string name = this._language.GetTokenName(expr.Operator.Type);
            int root = this.AddNode("binary " + name);

            this.AddDottedConnection(root, left);
            this.AddDottedConnection(root, right);

            return root;
        }

        private int GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            int child = this.EvaluateExpression(expr.Expression);
            int root = this.AddNode("grouping");

            this.AddDottedConnection(root, child);

            return root;
        }

        private int LiteralExpression(Expr expression)
        {
            Literal expr = (Literal)expression;

            string name = this._language.GetTokenName(expr.Value.Type);
            string text = "literal " + name;

            if (!string.IsNullOrEmpty(expr.Value.Value))
            {
                text += "\nvalue: " + expr.Value.Value;
            }

            int root = this.AddNode(text);

            return root;
        }

        private int LogicalExpression(Expr expression)
        {
            Logical expr = (Logical)expression;

            int left = this.EvaluateExpression(expr.Left);
            int right = this.EvaluateExpression(expr.Right);

            string name = this._language.GetTokenName(expr.Operator.Type);
            int root = this.AddNode("logical " + name);

            this.AddDottedConnection(root, left);
            this.AddDottedConnection(root, right);

            return root;
        }

        private int UnaryExpression(Expr expression)
        {
            Unary expr = (Unary)expression;

            int child = this.EvaluateExpression(expr.Right);

            string name = this._language.GetTokenName(expr.Operator.Type);
            int root = this.AddNode("unary " + name);

            this.AddDottedConnection(root, child);

            return root;
        }

        private int VariableExpression(Expr expression)
        {
            Variable expr = (Variable)expression;

            string name = expr.Identifier.Value;
            string text = "variable " + name;
            int root = this.AddNode(text);

            return root;
        }

        private int CallExpression(Expr expression)
        {
            Call expr = (Call)expression;

            string text = "call";
            int root = this.AddNode(text);

            return root;
        }
    }
}