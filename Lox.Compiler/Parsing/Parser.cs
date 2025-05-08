using System;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing
{
    public sealed class Parser
    {
        private readonly Logger _logger;
        private ParserData _parserData;

        public Parser(Logger logger)
        {
            this._logger = logger;
        }

        public Expr Run(ScanResult scanResult)
        {
            this._parserData = new ParserData(scanResult);

            return this.Expression();
        }

/*
        private void Synchronize()
        {
            this._parserData.Advance();

            while (!this._parserData.IsAtEnd())
            {
                ETokenType currentType = this._parserData.Peek().Type;
                ETokenType previousType = this._parserData.Previous().Type;

                if (previousType == TokenType.SEMICOLON)
                {
                    // end of line
                    return;
                }

                switch (currentType)
                {
                    case TokenType.CLASS:
                    case TokenType.FUN:
                    case TokenType.VAR:
                    case TokenType.FOR:
                    case TokenType.IF:
                    case TokenType.WHILE:
                    case TokenType.PRINT:
                    case TokenType.RETURN:
                        return;

                    default:
                        break;
                }

                this._parserData.Advance();
            }
        }
*/

        private Expr Expression()
        {
            return this.Equality();
        }

        private Expr Equality()
        {
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

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
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

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
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

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
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

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
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

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
            if (this._parserData == null)
            {
                throw new NullReferenceException("Parser._parserData not initialized.");
            }

            // false
            if (this._parserData.Match(TokenType.FALSE))
            {
                return new Literal(false);
            }

            // true
            if (this._parserData.Match(TokenType.TRUE))
            {
                return new Literal(true);
            }

            // nil
            if (this._parserData.Match(TokenType.NIL))
            {
                return new Literal(null);
            }

            // 10
            // text
            if (this._parserData.Match(TokenType.NUMBER)
                || this._parserData.Match(TokenType.STRING))
            {
                return new Literal(this._parserData.Previous().Value);
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