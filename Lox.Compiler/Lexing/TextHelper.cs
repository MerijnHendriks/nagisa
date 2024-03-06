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
    }
}