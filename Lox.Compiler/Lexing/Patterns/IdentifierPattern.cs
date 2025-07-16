using System.IO;

namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class IdentifierPattern : Pattern
    {
        private const int MAX_IDENTIFIER_LENGTH = 31;

        private readonly TextHelper _textHelper;

        public IdentifierPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsIdentifier(source, current.Index)
                && !this._textHelper.IsDigit(source, current.Index);
        }

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            SourcePosition next = new SourcePosition(file, current.Index, current.Line, current.Column);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (!this._textHelper.IsIdentifier(source, next.Index))
                {
                    // End of identifier
                    break;
                }

                next.Index += 1;
            }

            int difference = next.Index - current.Index;

            if (difference > MAX_IDENTIFIER_LENGTH)
            {
                string format = "Identifier at {0} is too long. Max 31 characters allowed.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            // Get token
            string value = source.Substring(current.Index, difference);
            token = new Token(file, current.Index, TokenType.IDENTIFIER, value);

            // Get position
            next.Column += difference;
            next.Index += 1;
            
            return next;
        }
    }
}