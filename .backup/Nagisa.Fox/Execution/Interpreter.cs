namespace Nagisa.Fox.Execution
{
    public sealed class Interpreter
    {
        private object Evaluate(Expr expression)
        {
            this._logger.WriteInfo("[EVAL] type: " + expression.Type);

            switch (expression.Type)
            {
                case ExprType.ASSIGN:
                    return this.AssignExpression(expression);

                case ExprType.CALL:
                    return this.CallExpression(expression);

                case ExprType.GET:
                    return this.GetExpression(expression);

                case ExprType.GROUPING:
                    return this.GroupingExpression(expression);

                case ExprType.LITERAL:
                    return this.LiteralExpression(expression);

                case ExprType.LOGICAL:
                    return this.LogicalExpression(expression);

                case ExprType.SET:
                    return this.SetExpression(expression);

                case ExprType.SUPER:
                    return this.SuperExpression(expression);

                case ExprType.THIS:
                    return this.ThisExpression(expression);

                case ExprType.UNARY:
                    return this.UnaryExpression(expression);

                case ExprType.VARIABLE:
                    return this.VariableExpression(expression);

                default:
                    throw new InvalidOperationException("Expression not implemented.");
            }
        }

        private object AssignExpression(Expr expression)
        {
            Assign expr = (Assign)expression;

            throw new NotImplementedException();
        }

        private object CallExpression(Expr expression)
        {
            Call expr = (Call)expression;

            throw new NotImplementedException();
        }

        private object GetExpression(Expr expression)
        {
            Get expr = (Get)expression;

            throw new NotImplementedException();
        }

        private object GroupingExpression(Expr expression)
        {
            Grouping expr = (Grouping)expression;

            return this.Evaluate(expression);
        }

        private object LogicalExpression(Expr expression)
        {
            Logical expr = (Logical)expression;

            throw new NotImplementedException();
        }

        private object SetExpression(Expr expression)
        {
            Set expr = (Set)expression;

            throw new NotImplementedException();
        }

        private object SuperExpression(Expr expression)
        {
            Super expr = (Super)expression;

            throw new NotImplementedException();
        }

        private object ThisExpression(Expr expression)
        {
            This expr = (This)expression;

            throw new NotImplementedException();
        }

        private object VariableExpression(Expr expression)
        {
            Variable expr = (Variable)expression;

            throw new NotImplementedException();
        }
    }
}