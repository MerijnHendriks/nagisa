using System;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Lexing
{
    public sealed class Scanner
    {
        private readonly Logger _logger;
        private readonly TextHelper _textHelper;
        private readonly Pattern[] _patterns;

        public Scanner(Logger logger, Pattern[] patterns)
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
                    throw new Exception("Invalid type.");
            }
        }
        #endif

        #if DEBUG
        private void PrintToken(Token token, SourcePosition current)
        {
            string format = "[{0}, {1}, {2}] {3}";
            string typeName = this.GetTokenName(token.Type);
            string formatted = string.Format(format, current.Index, current.Line, current.Column, typeName);

            if (!string.IsNullOrEmpty(token.Value))
            {
                formatted += (", " + token.Value);
            }

            _logger.WriteInfo(formatted);
        }
        #endif

        private SourcePosition ScanToken(string file, string source, SourcePosition current, ref Token token)
        {
            for (int i = 0; i < this._patterns.Length; ++i)
            {
                Pattern pattern = this._patterns[i];

                if (!pattern.IsMatch(source, current))
                {
                    continue;
                }

                return pattern.Run(file, source, current, ref token);
            }

            string format = "[{0}]: No matching pattern for {1} at [idx:{2},ln:{3},col:{4}].";
            string error = string.Format(format, file, source[current.Index], current.Index, current.Line, current.Column);
            throw new PatternMatchingException(error);
        }

        public ScanResult Run(string file, string source)
        {
            Token token = new Token();
            SourcePosition current = new SourcePosition(file, 0, 1, 1);
            SourcePosition next = current;
            ScanResult result = new ScanResult();

            // Tokenize source
            while (!this._textHelper.IsAtEnd(source, current.Index))
            {
                next = this.ScanToken(file, source, current, ref token);

                if (token.Type != TokenType.INVALID)
                {
                    // Add to result
                    result.Tokens.Add(token);
                    result.Sourcemap.Add(current);

                    #if DEBUG
                    this.PrintToken(token, current);
                    #endif
                }

                current = next;
            }

            // Add End-Of-File token
            token = new Token(file, current.Index, TokenType.END_OF_FILE, string.Empty);
            result.Tokens.Add(token);
            result.Sourcemap.Add(current);

            #if DEBUG
            this.PrintToken(token, current);
            #endif

            return result;
        }
    }
}