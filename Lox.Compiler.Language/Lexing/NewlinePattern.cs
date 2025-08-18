/*
    MODE | CHAR | PLATFORM
    CRLF | \r\n | Windows, serial
    CR:  | \r   | Macintosh
    LF   | \n   | Unix
*/

using Lox.Compiler.Lexing;

namespace Lox.Compiler.Language.Lexing
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
                && this._textHelper.IsNewLine(source, current.Index))
            {
                return true;
            }

            // \r      
            if (this._textHelper.IsCarriageReturn(source, current.Index))
            {
                return true;
            }

            // \n
            if (this._textHelper.IsLineFeed(source, current.Index))
            {
                return true;
            }

            return false;
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            // Get token
            Token token = new Token(file, current.Index, TokenType.END_OF_LINE, null);

            // Get position
            int nextIndex = current.Index;

            if (this._textHelper.IsNewLine(source, current.Index))
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

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }
}