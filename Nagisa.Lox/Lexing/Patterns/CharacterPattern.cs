using Nagisa.Lox.Lexing;

namespace Nagisa.Lox.Lexing.Patterns
{
    public class CharacterPattern : Pattern
    {
        private readonly TextHelper _textHelper;
        private readonly char _target;
        private readonly int _type;

        public CharacterPattern(char target, int type)
        {
            this._textHelper = new TextHelper();
            this._target = target;
            this._type = type;
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsMatchChar(source, current.Index, this._target);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            return this.RunOffset(file, source, current, this._type, 1);
        }
    }
}