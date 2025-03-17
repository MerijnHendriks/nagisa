using System;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing
{
    public sealed class Parser
    {
        private int _current;
        private ScanResult _scanResult;
        private readonly Logger _logger;

        public Parser(Logger logger)
        {
            this._logger = logger;
        }

        public Expr Run(ScanResult scanResult)
        {
            this._current = 0;
            this._scanResult = scanResult;

            return this.Expression();
        }

/*
        private void Synchronize()
        {
            this.Advance();

            while (!this.IsAtEnd())
            {
                if (this.Previous().Type == TokenType.SEMICOLON)
                {
                    // end of line
                    return;
                }

                switch (this.Peek().Type)
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

                this.Advance();
            }
        }
*/

        private Expr Expression()
        {
            return this.Equality();
        }

        // EQUALITY
        // a != b
        // a == b
        private Expr Equality()
        {
            Expr expr = this.Comparison();

            while (this.Match(TokenType.EQUAL)
                || this.Match(TokenType.NOT_EQUAL))
            {
                Token op = this.Previous();
                Expr right = this.Comparison();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        // COMPARISON
        // a <= b
        // a < b
        // a >= b
        // a > b
        private Expr Comparison()
        {
            Expr expr = this.Term();

            while (this.Match(TokenType.GREATER_EQUAL)
                || this.Match(TokenType.RIGHT_ARROW)
                || this.Match(TokenType.LESS_EQUAL)
                || this.Match(TokenType.LEFT_ARROW))
            {
                Token op = this.Previous();
                Expr right = this.Term();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        // TERM:
        // a - b
        // a + b
        private Expr Term()
        {
            Expr expr = this.Factor();

            while (this.Match(TokenType.MINUS)
                || this.Match(TokenType.PLUS))
            {
                Token op = this.Previous();
                Expr right = this.Factor();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        // FACTOR:
        // a / b
        // a * b
        private Expr Factor()
        {
            Expr expr = this.Unary();

            while (this.Match(TokenType.SLASH)
                || this.Match(TokenType.STAR))
            {
                Token op = this.Previous();
                Expr right = this.Unary();
                expr = new Binary(expr, op, right);
            }

            return expr;
        }

        // UNARY:
        // -10
        // !10
        private Expr Unary()
        {
            if (this.Match(TokenType.NOT)
             || this.Match(TokenType.MINUS))
            {
                Token op = this.Previous();
                Expr right = this.Unary();
                return new Unary(op, right);
            }

            return this.Primary();
        }

        private Expr Primary()
        {
            if (this.Match(TokenType.FALSE))
            {
                return new Literal(false);
            }

            if (this.Match(TokenType.TRUE))
            {
                return new Literal(true);
            }

            if (this.Match(TokenType.NIL))
            {
                return new Literal(null);
            }

            if (this.Match(TokenType.NUMBER)
             || this.Match(TokenType.STRING))
            {
                return new Literal(this.Previous().Value);
            }

            if (this.Match(new int[] { TokenType.LEFT_CIRCLE }))
            {
                Expr expr = this.Expression();
                this.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after expression.");
                return new Grouping(expr);
            }

            throw ExpressionError();
        }

        private InvalidOperationException ExpressionError()
        {
            SourcePosition position = this._scanResult.Sourcemap[this._current];
            string format = "[{0}]: Expected expression for token {1} at [idx:{2},ln:{3},col:{4}].";
            string message = string.Format(
                format,
                position.File,
                this.Peek().Type,
                position.Index,
                position.Line,
                position.Column);

            return new InvalidOperationException(message);
        }

        private bool Match(int type)
        {
            if (this.Check(type))
            {
                this.Advance();
                return true;
            }

            return false;
        }

        private bool Match(int[] types)
        {
            foreach (int type in types)
            {
                this.Match(type);
            }

            return false;
        }

        private Token Consume(int type, string message)
        {
            if (this.Check(type))
            {
                return this.Advance();
            }

            throw new InvalidOperationException(this.Peek() + message);
        }

        private Token Advance()
        {
            if (!this.IsAtEnd())
            {
                ++this._current;
            }

            return this.Previous();
        }

        private bool Check(int type)
        {
            if (this.IsAtEnd())
            {
                return false;
            }

            return this.Peek().Type == type;
        }

        private bool IsAtEnd()
        {
            if (this.Peek().Type == TokenType.END_OF_FILE)
            {
                return true;
            }

            return false;
        }

        private Token Peek() 
        {
            return this._scanResult.Tokens[this._current];
        }

        private Token Previous()
        {
            return this._scanResult.Tokens[this._current - 1];
        }
    }
}