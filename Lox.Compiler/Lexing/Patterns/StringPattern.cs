using System.IO;

namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class StringPattern : Pattern
    {
        private const char DELIMITER = '"';

        private readonly TextHelper _textHelper;

        public StringPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsMatchChar(source, current.Index, DELIMITER);
        }

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            bool foundDelimiter = false;
            int startIndex = current.Index + 1;
            int startColumn = current.Column + 1;
            SourcePosition next = new SourcePosition(file, startIndex, current.Line, startColumn);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    if (this._textHelper.IsMatchChar(source, next.Index - 1, '\\'))
                    {
                        // Escaped string
                    }
                    else
                    {
                        // End of string
                        foundDelimiter = true;
                        break;
                    }
                }

                next.Index += 1;
            }

            if (!foundDelimiter)
            {
                string format = "String at {0} not closed.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            int difference = next.Index - startIndex;

            // Get token
            string value = source.Substring(startIndex, difference);
            token = new Token(file, current.Index, TokenType.STRING, value);

            // Get position
            next.Column += difference;
            next.Index += 1;

            return next;
        }
    }
}