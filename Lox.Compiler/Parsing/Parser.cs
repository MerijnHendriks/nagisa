using System;
using System.Collections.Generic;
using Lox.Compiler.Lexing;
using Lox.Compiler.Parsing.Expressions;

namespace Lox.Compiler.Parsing
{
    public sealed class Parser
    {
        private int _current;
        private List<Token> _tokens;
        
        private readonly int[] _equalityTokens = new int[]
        {
            TokenType.NOT_EQUAL,
            TokenType.EQUAL
        };
        private readonly int[] _comparisonTokens = new int[]
        {
            TokenType.RIGHT_ARROW,
            TokenType.GREATER_EQUAL,
            TokenType.LEFT_ARROW,
            TokenType.LESS_EQUAL
        };
        private readonly int[] _termTokens = new int[]
        {
            TokenType.MINUS,
            TokenType.PLUS
        };
        private readonly int[] _factorTokens = new int[]
        {
            TokenType.SLASH,
            TokenType.STAR
        };
        private readonly int[] _unaryTokens = new int[]
        {
            TokenType.NOT,
            TokenType.MINUS
        };
        private readonly int[] _falseTokens = new int[]
        {
            TokenType.FALSE
        };
        private readonly int[] _trueTokens = new int[]
        {
            TokenType.TRUE
        };
        private readonly int[] _nilTokens = new int[]
        {
            TokenType.NIL
        };
        private readonly int[] _literalTokens = new int[]
        {
            TokenType.NUMBER,
            TokenType.STRING
        };

        public Expr Run(ScanResult result)
        {
            this._current = 0;
            this._tokens = result.Tokens;

            try
            {
                return this.Expression();
            }
            catch
            {
                return null;
            }
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

            while (this.Match(this._equalityTokens))
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

            while (this.Match(this._comparisonTokens))
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

            while (this.Match(this._termTokens))
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

            while (this.Match(this._factorTokens))
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
            if (this.Match(this._unaryTokens))
            {
                Token op = this.Previous();
                Expr right = this.Unary();
                return new Unary(op, right);
            }

            return this.Primary();
        }

        private Expr Primary()
        {
            if (this.Match(this._falseTokens))
            {
                return new Literal(false);
            }

            if (this.Match(this._trueTokens))
            {
                return new Literal(true);
            }

            if (this.Match(this._nilTokens))
            {
                return new Literal(null);
            }

            if (this.Match(this._literalTokens))
            {
                return new Literal(this.Previous().Value);
            }

            if (this.Match(new int[] { TokenType.LEFT_CIRCLE }))
            {
                Expr expr = this.Expression();
                this.Consume(TokenType.RIGHT_CIRCLE, "Expect ')' after expression.");
                return new Grouping(expr);
            }

            string format = "Expected expression for token {0}.";
            string message = string.Format(format, this.Peek().Type);
            throw new InvalidOperationException(message);
        }

        private bool Match(int[] types)
        {
            foreach (int type in types)
            {
                if (this.Check(type))
                {
                    this.Advance();
                    return true;
                }
            }

            return false;
        }

        private Token Advance()
        {
            if (!this.IsAtEnd())
            {
                this._current++;
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
            return this.Peek().Type == TokenType.END_OF_FILE;
        }

        private Token Peek() 
        {
            return this._tokens[this._current];
        }

        private Token Previous()
        {
            return this._tokens[this._current - 1];
        }

        private Token Consume(int type, string message)
        {
            if (this.Check(type))
            {
                return this.Advance();
            }

            throw new Exception(this.Peek() + message);
        }
    }
}