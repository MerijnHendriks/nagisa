namespace Lox.Compiler.Lexing.Patterns
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

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            return this.RunOffset(file, source, current, ref token, this._type, 1);
        }
    }
}