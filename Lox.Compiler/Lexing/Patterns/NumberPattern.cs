using System.IO;

namespace Lox.Compiler.Lexing.Patterns
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

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            int delimiter = 0;
            SourcePosition next = new SourcePosition(file, current.Index, current.Line, current.Column);

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
                    ++delimiter;
                }

                ++next.Index;
            }

            if (delimiter > 1)
            {
                string format = "Number at {0} has too many delimiters.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            int difference = next.Index - current.Index;

            // Get token
            string value = source.Substring(current.Index, difference);
            token = new Token(file, current.Index, TokenType.NUMBER, value);

            // Get position
            next.Column += difference;

            return next;
        }
    }
}