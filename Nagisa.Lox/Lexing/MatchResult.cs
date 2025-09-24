namespace Nagisa.Lox.Lexing
{
    public sealed class MatchResult
    {
        public readonly Token Token;
        public readonly SourcePosition Position;

        public MatchResult(Token token, SourcePosition position)
        {
            this.Token = token;
            this.Position = position;
        }
    }
}