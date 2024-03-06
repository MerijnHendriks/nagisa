/*
    MODE | CHAR | PLATFORM
    CRLF | \r\n | Windows, serial
    CR:  | \r   | Macintosh
    LF   | \n   | Unix
*/

namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class NewlinePattern : Pattern
    {
        private readonly TextHelper _textHelper;

        public NewlinePattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            // \r\n
            if (!this._textHelper.IsAtEnd(source, current.Index + 1)
                && this._textHelper.IsEndOfLine(source, current.Index))
            {
                return true;
            }

            // \r or \n      
            if (this._textHelper.IsCarriageReturn(source, current.Index)
                || this._textHelper.IsLineFeed(source, current.Index))
            {
                return true;
            }

            return false;
        }

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            // Get token
            token = new Token(file, current.Index, TokenType.END_OF_LINE, string.Empty);

            // Get position
            int nextIndex = current.Index;

            if (this._textHelper.IsEndOfLine(source, current.Index))
            {
                // \r\n
                nextIndex += 2;
            }
            else
            {
                // \r or \n
                nextIndex += 1;
            }

            SourcePosition next = new SourcePosition(file, nextIndex, current.Line + 1, 1);

            return next;
        }
    }
}