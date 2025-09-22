using System;
using System.Collections.Generic;
using Nagisa.Core.Common;

namespace Nagisa.Core.Lexing
{
    public sealed class Scanner
    {
        private readonly Logger _logger;
        private readonly LanguageData _language;
        private readonly TextHelper _textHelper;

        public Scanner(Logger logger,LanguageData language)
        {
            this._logger = logger;
            this._language = language;
            this._textHelper = new TextHelper();
        }

#if DEBUG
        private void PrintToken(Token token)
        {
            string name = this._language.GetTokenName(token.Type);
            string format = "[{0}, {1}, {2}] {3}";
            string message = string.Format(format, token.Index, token.Line, token.Column, name);

            if (token.Value != null)
            {
                message += ", ";
                message += token.Value.ToString();
            }

            this._logger.WriteInfo(message);
        }
#endif

        private MatchResult ScanToken(string file, string source, SourcePosition position)
        {
            List<Pattern> patterns = this._language.GetPatterns();

            for (int i = 0; i < patterns.Count; i += 1)
            {
                Pattern pattern = patterns[i];

                if (!pattern.IsMatch(source, position))
                {
                    continue;
                }

                return pattern.Run(file, source, position);
            }

            string format = "[{0}]: No matching pattern for {1} at [idx:{2},ln:{3},col:{4}].";
            string message = string.Format(format, file, source[position.Index], position.Index, position.Line, position.Column);
            throw new ArgumentOutOfRangeException(message);
        }

        public List<Token> ScanFile(string file, string source)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            List<Token> result = new List<Token>();
            SourcePosition position = new SourcePosition(0, 1, 1);

            // TODO: Rewrite as for loop!
            // Tokenize source
            while (!this._textHelper.IsAtEnd(source, position.Index))
            {
                MatchResult match = this.ScanToken(file, source, position);

                if (match.Token.Type != TokenType.INVALID)
                {
                    // Add to result
                    result.Add(match.Token);

#if DEBUG
                    this.PrintToken(match.Token);
#endif
                }

                position = match.Position;
            }

            // Add End-Of-File token
            Token eofToken = new Token(file, position, TokenType.END_OF_FILE, null);
            result.Add(eofToken);

#if DEBUG
            this.PrintToken(eofToken);
#endif

            return result;
        }
    }
}