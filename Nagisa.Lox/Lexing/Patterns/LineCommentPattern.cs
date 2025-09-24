using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Lexing.Patterns
{
    public sealed class LineCommentPattern : Pattern
    {
        private const string TARGET = "//";

        private readonly TextHelper _textHelper;
        private readonly Pattern _newlinePattern;

        public LineCommentPattern()
        {
            this._textHelper = new TextHelper();
            this._newlinePattern = new NewlinePattern();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsMatchString(source, current.Index, TARGET);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            int startIndex = current.Index + TARGET.Length;
            int startColumn = current.Column + TARGET.Length;
            SourcePosition next = new SourcePosition(startIndex, current.Line, startColumn);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (this._newlinePattern.IsMatch(source, next))
                {
                    // End of line comment
                    break;
                }

                next.Index += 1;
            }

            int difference = next.Index - startIndex;

            // Get token
            string value = source.Substring(startIndex, difference);
            Token token = new Token(file, current, TokenType.LINE_COMMENT, value);

            // Get position
            next.Column += difference;
            next.Index += 1;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }
}