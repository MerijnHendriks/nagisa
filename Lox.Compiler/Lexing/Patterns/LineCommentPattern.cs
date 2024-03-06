namespace Lox.Compiler.Lexing.Patterns
{
    public class LineCommentPattern : Pattern
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
            return this._textHelper.IsMatchText(source, current.Index, TARGET);
        }

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            int startIndex = current.Index + TARGET.Length;
            int startColumn = current.Column + TARGET.Length;
            SourcePosition next = new SourcePosition(file, startIndex, current.Line, startColumn);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (this._newlinePattern.IsMatch(source, next))
                {
                    // end of line comment
                    break;
                }

                ++next.Index;
            }

            int difference = next.Index - startIndex;

            // get token
            string value = source.Substring(startIndex, difference);
            token = new Token(file, current.Index, ETokenType.LineComment, value);

            next.Column += difference;
            ++next.Index;

            return next;
        }
    }
}