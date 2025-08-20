namespace Nagisa.Core.Parsing
{
    public sealed class Parser
    {
        private void Synchronize()
        {
            this._parserData.Advance();

            while (!this._parserData.IsAtEnd())
            {
                ETokenType currentType = this._parserData.Peek().Type;
                ETokenType previousType = this._parserData.Previous().Type;

                if (previousType == TokenType.SEMICOLON)
                {
                    // end of line
                    return;
                }

                switch (currentType)
                {
                    case TokenType.CLASS:
                    case TokenType.FUN:
                    case TokenType.VAR:
                    case TokenType.FOR:
                    case TokenType.IF:
                    case TokenType.WHILE:
                    case TokenType.PRINT:
                    case TokenType.RETURN:
                        return;

                    default:
                        break;
                }

                this._parserData.Advance();
            }
        }
    }
}