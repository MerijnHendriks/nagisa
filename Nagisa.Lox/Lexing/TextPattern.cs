using Nagisa.Core.Lexing;

namespace Nagisa.Lox.Lexing
{
    public class TextPattern : Pattern
    {
        private readonly TextHelper _textHelper;
        private readonly string _target;
        private readonly int _type;

        public TextPattern(string target, int type)
        {
            this._textHelper = new TextHelper();
            this._target = target;
            this._type = type;
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsMatchString(source, current.Index, this._target);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            return this.RunOffset(file, source, current, this._type, this._target.Length);
        }
    }
}