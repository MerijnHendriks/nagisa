using System;
using System.IO;

namespace Nagisa.Fox.Lexing
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

    public sealed class IdentifierPattern : Pattern
    {
        private const int MAX_IDENTIFIER_LENGTH = 31;

        private readonly TextHelper _textHelper;

        public IdentifierPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsIdentifier(source, current.Index)
                && !this._textHelper.IsDigit(source, current.Index);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            SourcePosition next = new SourcePosition(current.Index, current.Line, current.Column);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (!this._textHelper.IsIdentifier(source, next.Index))
                {
                    // End of identifier
                    break;
                }

                next.Index += 1;
            }

            int difference = next.Index - current.Index;

            if (difference > MAX_IDENTIFIER_LENGTH)
            {
                string format = "Identifier at {0} is too long. Max 31 characters allowed.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            // Get token
            string value = source.Substring(current.Index, difference);
            Token token = new Token(file, current, TokenType.IDENTIFIER, value);

            // Get position
            next.Column += difference;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }

    public sealed class LineCommentPattern : Pattern
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
            return this._textHelper.IsMatchString(source, current.Index, TARGET);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            int startIndex = current.Index + TARGET.Length;
            int startColumn = current.Column + TARGET.Length;
            SourcePosition next = new SourcePosition(startIndex, current.Line, startColumn);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (this._newlinePattern.IsMatch(source, next))
                {
                    // End of line comment
                    break;
                }

                next.Index += 1;
            }

            int difference = next.Index - startIndex;

            // Get token
            string value = source.Substring(startIndex, difference);
            Token token = new Token(file, current, TokenType.LINE_COMMENT, value);

            // Get position
            next.Column += difference;
            next.Index += 1;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }

    /*
        MODE | CHAR | PLATFORM
        CRLF | \r\n | Windows, serial
        CR:  | \r   | Macintosh
        LF   | \n   | Unix
    */
    public sealed class NewlinePattern : Pattern
    {
        private readonly TextHelper _textHelper;

        public NewlinePattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            // \r\n
            if (!this._textHelper.IsAtEnd(source, current.Index + 1)
                && this._textHelper.IsNewLine(source, current.Index))
            {
                return true;
            }

            // \r      
            if (this._textHelper.IsCarriageReturn(source, current.Index))
            {
                return true;
            }

            // \n
            if (this._textHelper.IsLineFeed(source, current.Index))
            {
                return true;
            }

            return false;
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            // Get token
            Token token = new Token(file, current, TokenType.END_OF_LINE, null);

            // Get position
            int nextIndex = current.Index;

            if (this._textHelper.IsNewLine(source, current.Index))
            {
                // \r\n
                nextIndex += 2;
            }
            else
            {
                // \r or \n
                nextIndex += 1;
            }

            SourcePosition next = new SourcePosition(nextIndex, current.Line + 1, 1);

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }

    public sealed class NumberPattern : Pattern
    {
        private const char DELIMITER = '.';

        private readonly TextHelper _textHelper;

        public NumberPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsDigit(source, current.Index);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            int delimiter = 0;
            SourcePosition next = new SourcePosition(current.Index, current.Line, current.Column);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (!this._textHelper.IsDigit(source, next.Index)
                    && !this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    // End of number
                    break;
                }

                if (this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    delimiter += 1;
                }

                next.Index += 1;
            }

            if (delimiter > 1)
            {
                string format = "Number at {0} has too many delimiters.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            int difference = next.Index - current.Index;

            // Get token
            string text = source.Substring(current.Index, difference);
            Token token = new Token(file, current, TokenType.NUMBER, text);

            // Get position
            next.Column += difference;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }

    public sealed class StringPattern : Pattern
    {
        private const char DELIMITER = '"';

        private readonly TextHelper _textHelper;

        public StringPattern()
        {
            this._textHelper = new TextHelper();
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            return this._textHelper.IsMatchChar(source, current.Index, DELIMITER);
        }

        public override MatchResult Run(string file, string source, SourcePosition current)
        {
            bool foundDelimiter = false;
            int startIndex = current.Index + 1;
            int startColumn = current.Column + 1;
            SourcePosition next = new SourcePosition(startIndex, current.Line, startColumn);

            while (!this._textHelper.IsAtEnd(source, next.Index))
            {
                if (this._textHelper.IsMatchChar(source, next.Index, DELIMITER))
                {
                    if (this._textHelper.IsMatchChar(source, next.Index - 1, '\\'))
                    {
                        // Escaped string
                    }
                    else
                    {
                        // End of string
                        foundDelimiter = true;
                        break;
                    }
                }

                next.Index += 1;
            }

            if (!foundDelimiter)
            {
                string format = "String at {0} not closed.";
                string message = string.Format(format, current.Index);
                throw new InvalidDataException(message);
            }

            int difference = next.Index - startIndex;

            // Get token
            string value = source.Substring(startIndex, difference);
            Token token = new Token(file, current, TokenType.STRING, value);

            // Get position
            next.Column += difference;
            next.Index += 1;

            MatchResult result = new MatchResult(token, next);
            return result;
        }
    }

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