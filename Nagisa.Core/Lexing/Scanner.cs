using System;
using System.Collections.Generic;
using Nagisa.Core.Common;

namespace Nagisa.Core.Lexing
{
    public sealed class Scanner
    {
        private readonly Logger _logger;
        private readonly TextHelper _textHelper;
        private readonly List<Pattern> _patterns;

        public Scanner(Logger logger, List<Pattern> patterns)
        {
            this._logger = logger;
            this._textHelper = new TextHelper();
            this._patterns = patterns;
        }

#if DEBUG
        private string GetTokenName(int type)
        {
            switch (type)
            {
                case TokenType.END_OF_FILE:      return "EOF";
                case TokenType.END_OF_LINE:      return "EOL";
                case TokenType.DOT:              return ".";
                case TokenType.COMMA:            return ",";
                case TokenType.SEMICOLON:        return ";";
                case TokenType.LEFT_CURLY:       return "{";
                case TokenType.RIGHT_CURLY:      return "}";
                case TokenType.LEFT_CIRCLE:      return "(";
                case TokenType.RIGHT_CIRCLE:     return ")";
                case TokenType.LEFT_ARROW:       return "<";
                case TokenType.RIGHT_ARROW:      return ">";
                case TokenType.ASSIGN:           return "=";
                case TokenType.NOT:              return "!";
                case TokenType.PLUS:             return "+";
                case TokenType.MINUS:            return "-";
                case TokenType.STAR:             return "*";
                case TokenType.SLASH:            return "/";
                case TokenType.EQUAL:            return "==";
                case TokenType.NOT_EQUAL:        return "!=";
                case TokenType.LESS_EQUAL:       return "<=";
                case TokenType.GREATER_EQUAL:    return ">=";
                case TokenType.ADD_ASSIGN:       return "+=";
                case TokenType.SUBSTRACT_ASSIGN: return "-=";
                case TokenType.MULTIPLY_ASSIGN:  return "*=";
                case TokenType.DIVIDE_ASSIGN:    return "/=";
                case TokenType.IDENTIFIER:       return "IDENTIFIER";
                case TokenType.NUMBER:           return "NUMBER";
                case TokenType.STRING:           return "STRING";
                case TokenType.TRUE:             return "true";
                case TokenType.FALSE:            return "false";
                case TokenType.NIL:              return "nil";
                case TokenType.THIS:             return "this";
                case TokenType.SUPER:            return "super";
                case TokenType.VAR:              return "var";
                case TokenType.FUN:              return "fun";
                case TokenType.CLASS:            return "class";
                case TokenType.AND:              return "and";
                case TokenType.OR:               return "or";
                case TokenType.IF:               return "if";
                case TokenType.ELSE:             return "else";
                case TokenType.WHILE:            return "while";
                case TokenType.FOR:              return "for";
                case TokenType.CONTINUE:         return "continue";
                case TokenType.BREAK:            return "break";
                case TokenType.RETURN:           return "return";
                case TokenType.PRINT:            return "print";
                case TokenType.LINE_COMMENT:     return "//";
                case TokenType.TAB:              return "\t";
                case TokenType.WHITESPACE:       return "' '";
                case TokenType.INVALID:
                default:
                    throw new ArgumentException("Invalid type.");
            }
        }
#endif

#if DEBUG
        private void PrintToken(Token token)
        {
            string typeName = this.GetTokenName(token.Type);
            string format = "[{0}, {1}, {2}] {3}";
            string formatted = string.Format(format, token.Index, token.Line, token.Column, typeName);

            if (token.Value != null)
            {
                formatted += ", ";
                formatted += token.Value.ToString();
            }

            this._logger.WriteInfo(formatted);
        }
#endif

        private MatchResult ScanToken(string file, string source, SourcePosition position)
        {
            for (int i = 0; i < this._patterns.Count; i += 1)
            {
                Pattern pattern = this._patterns[i];

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

        public List<Token> Run(string file, string source)
        {
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