using System;

namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class IdentifierPattern : Pattern
    {
        private readonly TextHelper _textHelper;

        public IdentifierPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsIdentifier(source, current.Index);
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

                ++next.Index;
            }

            int difference = next.Index - current.Index;

            if (difference > 31)
            {
                string format = "Identifier at {0} is too long. Max 31 characters allowed.";
                string error = string.Format(format, current.Index);
                throw new Exception(error);
            }

            // Get token
            string value = source.Substring(current.Index, difference);
            token = new Token(file, current.Index, ETokenType.Identifier, value);

            // Get position
            next.Column += difference;
            ++next.Index;
            
            return next;
        }
    }
}