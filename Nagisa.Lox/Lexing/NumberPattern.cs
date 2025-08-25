using System;
using System.Globalization;
using System.IO;
using Nagisa.Core.Lexing;

namespace Nagisa.Lox.Lexing
{
    public sealed class NumberPattern : Pattern
    {
        private const char DELIMITER = '.';

        private readonly TextHelper _textHelper;

        public NumberPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsDigit(source, current.Index);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            int delimiter = 0;
            SourcePosition next = new SourcePosition(current.Index, current.Line, current.Column);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (!this._textHelper.IsDigit(source, next.Index)
                    && !this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    // End of number
                    break;
                }

                if (this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    delimiter += 1;
                }

                next.Index += 1;
            }

            if (delimiter > 1)
            {
                string format = "Number at {0} has too many delimiters.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            int difference = next.Index - current.Index;

            // Get token
            string text = source.Substring(current.Index, difference);
            Token token = new Token(file, current, TokenType.NUMBER, text);

            // Get position
            next.Column += difference;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }
}