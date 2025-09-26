using System;
using System.Collections.Generic;
using Nagisa.Fox.Common;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Parsing
{
    public sealed class ParserData
    {
        private readonly Logger _logger;
        private readonly List<Token> _tokens;
        private int _current;

        public ParserData(Logger logger, List<Token> tokens)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            if (tokens == null)
            {
                throw new ArgumentNullException("tokens");
            }

            this._logger = logger;
            this._tokens = tokens;
            this._current = 0;
        }

        public bool Match(int type)
        {
            if (this.Check(type))
            {
                this.Advance();
                return true;
            }

            return false;
        }

        public Token Consume(int type, string message)
        {
            if (this.Check(type))
            {
                return this.Advance();
            }

            this._logger.WriteError(message);
            throw new InvalidOperationException(message);
        }

        public Token Advance()
        {
            if (!this.IsAtEnd())
            {
                this._current += 1;
            }

            return this.Previous();
        }

        public bool Check(int type)
        {
            if (this.IsAtEnd())
            {
                return false;
            }

            return this.Peek().Type == type;
        }

        public bool IsAtEnd()
        {
            if (this.Peek().Type == TokenType.END_OF_FILE)
            {
                return true;
            }

            return false;
        }

        public string ExpressionErrorMessage()
        {
            Token token = this.Peek();
            string format = "[{0}]: Expected expression for token {1} at [idx:{2},ln:{3},col:{4}].";
            string message = string.Format(
                format,
                token.File,
                token.Type,
                token.Index,
                token.Line,
                token.Column);

            return message;
        }

        public Token Peek()
        {
            return this._tokens[this._current];
        }

        public Token Previous()
        {
            return this._tokens[this._current - 1];
        }

        public void Rewind()
        {
            this._current -= 1;
        }
    }

    public sealed class Parser
    {
        public List<Stmt> Parse(Logger logger, List<Token> tokens)
        {
            ParserData parserData = new ParserData(logger, tokens);
            List<Stmt> statements = new List<Stmt>();

            while (!parserData.IsAtEnd())
            {
                Stmt statement = this.Declaration(parserData);
                statements.Add(statement);
            }

            return statements;
        }

        // Declarations

        private Stmt Declaration(ParserData parserData)
        {
            if (parserData.Match(TokenType.VAR))
            {
                return this.VarDeclaration(parserData);
            }

            return this.Statement(parserData);
        }

        // var a = 10;
        private Stmt VarDeclaration(ParserData parserData)
        {
            Expr expr = this.Expression(parserData);
            Variable variable = (Variable)expr;

            if (expr.Type != ExprType.VARIABLE)
            {
                throw new InvalidOperationException("Expect variable identifier.");
            }

            if (!parserData.Match(TokenType.ASSIGN))
            {
                throw new InvalidOperationException("Variable must be initialized.");
            }

            Expr value = this.Expression(parserData);

            parserData.Consume(TokenType.SEMICOLON, "Expect ';' after variable declaration.");

            return new Var(variable, value);
        }

        // Statements

        private Stmt Statement(ParserData parserData)
        {
            if (parserData.Peek().Type == TokenType.IDENTIFIER)
            {
                parserData.Advance();

                if (parserData.Peek().Type == TokenType.ASSIGN
                    || parserData.Peek().Type == TokenType.ADD_ASSIGN
                    || parserData.Peek().Type == TokenType.SUBSTRACT_ASSIGN
                    || parserData.Peek().Type == TokenType.MULTIPLY_ASSIGN
                    || parserData.Peek().Type == TokenType.DIVIDE_ASSIGN
                    || parserData.Peek().Type == TokenType.MODULO_ASSIGN)
                {
                    parserData.Rewind();

                    return this.AssignStatement(parserData);
                }

                // likely an expression statement
                parserData.Rewind();
            }

            if (parserData.Match(TokenType.IF))
            {
                return this.IfStatement(parserData);
            }

            if (parserData.Match(TokenType.WHILE))
            {
                return this.WhileStatement(parserData);
            }

            if (parserData.Match(TokenType.PRINT))
            {
                return this.PrintStatement(parserData);
            }

            if (parserData.Match(TokenType.LEFT_CURLY))
            {
                return this.BlockStatement(parserData);
            }

            return this.ExpressionStatement(parserData);
        }

        // a = 10;
        // a += 10;
        // a -= 10;
        // a *= 10;
        // a /= 10;
        private Stmt AssignStatement(ParserData parserData)
        {
            Expr expr = this.Expression(parserData);

            if (expr.Type != ExprType.VARIABLE)
            {
                throw new InvalidOperationException("Invalid assignment target");
            }

            Variable variable = (Variable)expr;
            Token op = parserData.Advance();
            Expr value = this.Expression(parserData);

            parserData.Consume(TokenType.SEMICOLON, "Expect ';' after value.");

            return new Assign(variable, op, value);
        }

        // if (a == b) { ... } else { ... }
        private Stmt IfStatement(ParserData parserData)
        {
            parserData.Consume(TokenType.LEFT_CIRCLE, "Expect '(' after 'if'.");

            Expr condition = this.Expression(parserData);

            parserData.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after 'if' condition.");

            Stmt thenBranch = this.Statement(parserData);
            Stmt elseBranch = null;

            if (parserData.Match(TokenType.ELSE))
            {
                elseBranch = this.Statement(parserData);
            }

            return new If(condition, thenBranch, elseBranch);
        }

        // print a
        private Stmt PrintStatement(ParserData parserData)
        {
            Expr value = this.Expression(parserData);

            parserData.Consume(TokenType.SEMICOLON, "Expect ';' after value.");

            return new Print(value);
        }

        private Stmt WhileStatement(ParserData parserData)
        {
            parserData.Consume(TokenType.LEFT_CIRCLE, "Expect '(' after 'if'.");

            Expr condition = this.Expression(parserData);

            parserData.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after 'if' condition.");

            Stmt body = this.Statement(parserData);

            return new While(condition, body);
        }

        private Stmt BlockStatement(ParserData parserData)
        {
            List<Stmt> statements = new List<Stmt>();

            while (!parserData.Check(TokenType.RIGHT_CURLY) && !parserData.IsAtEnd())
            {
                statements.Add(this.Declaration(parserData));
            }

            parserData.Consume(TokenType.RIGHT_CURLY, "Expect '}' after block.");

            return new Block(statements);
        }

        private Stmt ExpressionStatement(ParserData parserData)
        {
            Expr value = this.Expression(parserData);

            parserData.Consume(TokenType.SEMICOLON, "Expect ';' after expression.");

            return new Expression(value);
        }

        // Expressions

        private Expr Expression(ParserData parserData)
        {
            Expr expr = this.Or(parserData);

            return expr;
        }

        private Expr Or(ParserData parserData)
        {
            Expr expr = this.And(parserData);

            while (parserData.Match(TokenType.OR))
            {
                Token op = parserData.Previous();
                Expr right = this.And(parserData);
                return new Logical(expr, op, right);
            }

            return expr;
        }

        private Expr And(ParserData parserData)
        {
            Expr expr = this.Equality(parserData);

            while (parserData.Match(TokenType.AND))
            {
                Token op = parserData.Previous();
                Expr right = this.Equality(parserData);
                return new Logical(expr, op, right);
            }

            return expr;
        }

        private Expr Equality(ParserData parserData)
        {
            Expr expr = this.Comparison(parserData);

            // a != b
            // a == b
            while (parserData.Match(TokenType.EQUAL)
                || parserData.Match(TokenType.NOT_EQUAL))
            {
                Token op = parserData.Previous();
                Expr right = this.Comparison(parserData);
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Comparison(ParserData parserData)
        {
            Expr expr = this.Term(parserData);

            // a <= b
            // a < b
            // a >= b
            // a > b
            while (parserData.Match(TokenType.GREATER_EQUAL)
                || parserData.Match(TokenType.RIGHT_ARROW)
                || parserData.Match(TokenType.LESS_EQUAL)
                || parserData.Match(TokenType.LEFT_ARROW))
            {
                Token op = parserData.Previous();
                Expr right = this.Term(parserData);
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Term(ParserData parserData)
        {
            Expr expr = this.Factor(parserData);

            // a - b
            // a + b
            while (parserData.Match(TokenType.MINUS)
                || parserData.Match(TokenType.PLUS))
            {
                Token op = parserData.Previous();
                Expr right = this.Factor(parserData);
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Factor(ParserData parserData)
        {
            Expr expr = this.Unary(parserData);

            // a / b
            // a * b
            // a % b
            while (parserData.Match(TokenType.SLASH)
                || parserData.Match(TokenType.STAR)
                || parserData.Match(TokenType.MODULO))
            {
                Token op = parserData.Previous();
                Expr right = this.Unary(parserData);
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Unary(ParserData parserData)
        {
            // -10
            // !10
            if (parserData.Match(TokenType.NOT)
                || parserData.Match(TokenType.MINUS))
            {
                Token op = parserData.Previous();
                Expr right = this.Unary(parserData);
                return new Unary(op, right);
            }

            return this.Primary(parserData);
        }

        private Expr Primary(ParserData parserData)
        {
            // false
            if (parserData.Match(TokenType.FALSE))
            {
                return new Literal(parserData.Previous());
            }

            // true
            if (parserData.Match(TokenType.TRUE))
            {
                return new Literal(parserData.Previous());
            }

            // nil
            if (parserData.Match(TokenType.NIL))
            {
                return new Literal(parserData.Previous());
            }

            // 10
            if (parserData.Match(TokenType.NUMBER))
            {
                return new Literal(parserData.Previous());
            }

            // text
            if (parserData.Match(TokenType.STRING))
            {
                return new Literal(parserData.Previous());
            }

            // identifier
            if (parserData.Match(TokenType.IDENTIFIER))
            {
                return new Variable(parserData.Previous());
            }

            // ( )
            if (parserData.Match(TokenType.LEFT_CIRCLE))
            {
                Expr expr = this.Expression(parserData);
                parserData.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after expression.");
                return new Grouping(expr);
            }

            // No matching expression found
            string message = parserData.ExpressionErrorMessage();
            throw new InvalidOperationException(message);
        }
    }
}