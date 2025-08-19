using System;
using System.Collections.Generic;
using Nagisa.Core.Lexing;

namespace Nagisa.Core.Parsing
{
    public sealed class ParserData
    {
        private int _current;
        private readonly List<Token> _tokens;

        public ParserData(List<Token> tokens)
        {
            this._current = 0;
            this._tokens = tokens;
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

            throw new InvalidOperationException(this.Peek() + message);
        }

        public Token Advance()
        {
            if (!this.IsAtEnd())
            {
                this._current  += 1;
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
    }
}