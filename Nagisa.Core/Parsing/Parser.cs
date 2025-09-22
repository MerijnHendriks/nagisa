using System;
using System.Collections.Generic;
using Nagisa.Core.Common;
using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing.Expressions;
using Nagisa.Core.Parsing.Statements;

namespace Nagisa.Core.Parsing
{
    public sealed class Parser
    {
        private readonly Logger _logger;
        private ParserData _parserData;

        public Parser(Logger logger)
        {
            this._logger = logger;
        }

        public List<Stmt> Run(List<Token> tokens)
        {
            this._parserData = new ParserData(this._logger, tokens);

            return this.Parse();
        }

        private void IsInitialized()
        {
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }
        }

        // Statements

        public List<Stmt> Parse()
        {
            List<Stmt> statements = new List<Stmt>();

            while (!this._parserData.IsAtEnd())
            {
                Stmt statement = this.Statement();
                statements.Add(statement);
            }

            return statements;
        }

        private Stmt Statement()
        {
            if (this._parserData.Match(TokenType.PRINT))
            {
                return this.PrintStatement();
            }

            return this.ExpressionStatement();
        }

        private Stmt PrintStatement()
        {
            Expr value = this.Expression();

            this._parserData.Consume(TokenType.SEMICOLON, "Expect ';' after value.");

            return new Print(value);
        }

        private Stmt ExpressionStatement()
        {
            Expr value = this.Expression();

            this._parserData.Consume(TokenType.SEMICOLON, "Expect ';' after expression.");

            return new Expression(value);
        }

        // Expressions

        private Expr Expression()
        {
            return this.Equality();
        }

        private Expr Equality()
        {
            this.IsInitialized();

            Expr expr = this.Comparison();

            // a != b
            // a == b
            while (this._parserData.Match(TokenType.EQUAL)
                || this._parserData.Match(TokenType.NOT_EQUAL))
            {
                Token op = this._parserData.Previous();
                Expr right = this.Comparison();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Comparison()
        {
            this.IsInitialized();

            Expr expr = this.Term();

            // a <= b
            // a < b
            // a >= b
            // a > b
            while (this._parserData.Match(TokenType.GREATER_EQUAL)
                || this._parserData.Match(TokenType.RIGHT_ARROW)
                || this._parserData.Match(TokenType.LESS_EQUAL)
                || this._parserData.Match(TokenType.LEFT_ARROW))
            {
                Token op = this._parserData.Previous();
                Expr right = this.Term();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Term()
        {
            this.IsInitialized();

            Expr expr = this.Factor();

            // a - b
            // a + b
            while (this._parserData.Match(TokenType.MINUS)
                || this._parserData.Match(TokenType.PLUS))
            {
                Token op = this._parserData.Previous();
                Expr right = this.Factor();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Factor()
        {
            this.IsInitialized();

            Expr expr = this.Unary();

            // a / b
            // a * b
            while (this._parserData.Match(TokenType.SLASH)
                || this._parserData.Match(TokenType.STAR))
            {
                Token op = this._parserData.Previous();
                Expr right = this.Unary();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        private Expr Unary()
        {
            this.IsInitialized();

            // -10
            // !10
            if (this._parserData.Match(TokenType.NOT)
                || this._parserData.Match(TokenType.MINUS))
            {
                Token op = this._parserData.Previous();
                Expr right = this.Unary();
                return new Unary(op, right);
            }

            return this.Primary();
        }

        private Expr Primary()
        {
            this.IsInitialized();

            // false
            if (this._parserData.Match(TokenType.FALSE))
            {
                return new Literal(TokenType.FALSE, string.Empty);
            }

            // true
            if (this._parserData.Match(TokenType.TRUE))
            {
                return new Literal(TokenType.TRUE, string.Empty);
            }

            // nil
            if (this._parserData.Match(TokenType.NIL))
            {
                return new Literal(TokenType.NIL, string.Empty);
            }

            // 10
            if (this._parserData.Match(TokenType.NUMBER))
            {
                return new Literal(TokenType.NUMBER, this._parserData.Previous().Value);
            }

            // text
            if (this._parserData.Match(TokenType.STRING))
            {
                return new Literal(TokenType.STRING, this._parserData.Previous().Value);
            }

            // ( )
            if (this._parserData.Match(TokenType.LEFT_CIRCLE))
            {
                Expr expr = this.Expression();
                this._parserData.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after expression.");
                return new Grouping(expr);
            }

            // No matching expression found
            string message = this._parserData.ExpressionErrorMessage();
            throw new InvalidOperationException(message);
        }
    }
}