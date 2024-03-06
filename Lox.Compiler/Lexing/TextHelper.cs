using System;

namespace Lox.Compiler.Lexing
{
    public sealed class TextHelper
    {
        private readonly char[] _alphaUpper;
        private readonly char[] _alphaLower;
        private readonly char[] _digits;

        public TextHelper()
        {
            this._alphaUpper = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z' 
            };
            this._alphaLower = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z'
            };
            this._digits = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        }

        public bool IsAtEnd(string source, int index)
        {
            return index >= source.Length;
        }

        public bool IsMatchChar(string source, int index, char target)
        {
            return source[index] == target;
        }

        public bool IsMatchText(string source, int start, string target)
        {
            for (int i = 0; i < target.Length; ++i)
            {
                int index = start + 1;

                if (!this.IsMatchChar(source, index, target[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsMatchCharArray(string source, int index, char[] targets)
        {
            for (int i = 0; i < targets.Length; ++i)
            {
                if (this.IsMatchChar(source, index, targets[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCarriageReturn(string source, int index)
        {
            return this.IsMatchChar(source, index, '\r');
        }

        public bool IsLineFeed(string source, int index)
        {
            return this.IsMatchChar(source, index, '\n');
        }

        public bool IsEndOfLine(string source, int index)
        {
            return this.IsCarriageReturn(source, index)
                && this.IsLineFeed(source, index + 1);
        }

        public bool IsAlphaUpper(string source, int index)
        {
            return this.IsMatchCharArray(source, index, this._alphaUpper);
        }

        public bool IsAlphaLower(string source, int index)
        {
            return this.IsMatchCharArray(source, index, this._alphaLower);
        }

        public bool IsDigit(string source, int index)
        {
            return this.IsMatchCharArray(source, index, this._digits);
        }

        public bool IsIdentifier(string source, int index)
        {
            return this.IsMatchChar(source, index, '_')
                || this.IsAlphaUpper(source, index)
                || this.IsAlphaLower(source, index)
                || this.IsDigit(source, index);
        }

        public string GetTokenTypeName(int type)
        {
            switch (type)
            {
                case TokenType.INVALID: return "--- ERROR ---";
                case TokenType.END_OF_FILE: return "EOF";
                case TokenType.END_OF_LINE: return "EOL";
                case TokenType.DOT: return ".";
                case TokenType.COMMA: return ",";
                case TokenType.SEMICOLON: return ";";
                case TokenType.LEFT_SQUARE: return "[";
                case TokenType.RIGHT_SQUARE: return "]";
                case TokenType.LEFT_CURLY: return "{";
                case TokenType.RIGHT_CURLY: return "}";
                case TokenType.LEFT_CIRCLE: return "(";
                case TokenType.RIGHT_CIRCLE: return ")";
                case TokenType.LEFT_ARROW: return "<";
                case TokenType.RIGHT_ARROW: return ">";
                case TokenType.ASSIGN: return "=";
                case TokenType.NOT: return "!";
                case TokenType.PLUS: return "+";
                case TokenType.MINUS: return "-";
                case TokenType.STAR: return "*";
                case TokenType.SLASH: return "/";
                case TokenType.EQUAL: return "==";
                case TokenType.NOT_EQUAL: return "!=";
                case TokenType.LESS_EQUAL: return "<=";
                case TokenType.GREATER_EQUAL: return ">=";
                case TokenType.ADD_ASSIGN: return "+=";
                case TokenType.SUBSTRACT_ASSIGN: return "-=";
                case TokenType.MULTIPLY_ASSIGN: return "*=";
                case TokenType.DIVIDE_ASSIGN: return "/=";
                case TokenType.IDENTIFIER: return "IDENTIFIER";
                case TokenType.NUMBER: return "NUMBER";
                case TokenType.STRING: return "STRING";
                case TokenType.TRUE: return "true";
                case TokenType.FALSE: return "false";
                case TokenType.NIL: return "nil";
                case TokenType.THIS: return "this";
                case TokenType.SUPER: return "super";
                case TokenType.VAR: return "var";
                case TokenType.FUN: return "fun";
                case TokenType.CLASS: return "class";
                case TokenType.AND: return "and";
                case TokenType.OR: return "or";
                case TokenType.IF: return "if";
                case TokenType.ELSE: return "else";
                case TokenType.WHILE: return "while";
                case TokenType.FOR: return "for";
                case TokenType.CONTINUE: return "continue";
                case TokenType.BREAK: return "break";
                case TokenType.RETURN: return "return";
                case TokenType.PRINT: return "print";
                case TokenType.LINE_COMMENT: return "//";
                case TokenType.TAB: return "\t";
                case TokenType.WHITESPACE: return "' '";
                case TokenType.BITSHIFT_LEFT: return "<<=";
                case TokenType.BITSHIFT_RIGHT: return ">>=";     
                case TokenType.BITWISE_AND: return "&";
                case TokenType.BITWISE_OR: return "|";
                case TokenType.BITWISE_XOR: return "^";
                case TokenType.BITWISE_COMPLEMENT: return "~";
                default:
                    throw new Exception("Invalid type.");
            }
        }
    }
}