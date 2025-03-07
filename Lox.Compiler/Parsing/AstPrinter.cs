using System;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing
{
    public sealed class AstPrinter : IExpressionVisitor<string>
    {
        public string Print(Expr expression)
        {
            return expression.Accept(this);
        }

        public string VisitAssignExpression(Assign expression)
        {
            throw new NotImplementedException();
        }

        public string VisitBinaryExpression(Binary expression)
        {
            throw new NotImplementedException();
        }

        public string VisitCallExpression(Call expression)
        {
            throw new NotImplementedException();
        }

        public string VisitGetExpression(Get expression)
        {
            throw new NotImplementedException();
        }

        public string VisitGroupingExpression(Grouping expression)
        {
            throw new NotImplementedException();
        }

        public string VisitLiteralExpression(Literal expression)
        {
            if (expression.Value == null)
            {
                return "nil";
            }

            return expression.Value.ToString();
        }

        public string VisitLogicalExpression(Logical expression)
        {
            throw new NotImplementedException();
        }

        public string VisitSetExpression(Set expression)
        {
            throw new NotImplementedException();
        }

        public string VisitSuperExpression(Super expression)
        {
            throw new NotImplementedException();
        }

        public string VisitThisExpression(This expression)
        {
            throw new NotImplementedException();
        }

        public string VisitUnaryExpression(Unary expression)
        {
            throw new NotImplementedException();
        }

        public string VisitVariableExpression(Variable expression)
        {
            throw new NotImplementedException();
        }
    }
}