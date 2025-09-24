namespace Nagisa.Lox.Parsing.Expressions
{
    public class ExprType
    {
        public const int NONE = 0;
        public const int BINARY = 1;
        public const int CALL = 2;
        public const int GET = 3;
        public const int GROUPING = 4;
        public const int LITERAL = 5;
        public const int LOGICAL = 6;
        public const int SET = 7;
        public const int SUPER = 8;
        public const int THIS = 9;
        public const int UNARY = 10;
        public const int VARIABLE = 11;
    }
}