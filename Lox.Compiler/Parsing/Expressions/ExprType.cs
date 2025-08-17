namespace Lox.Compiler.Parsing.Expressions
{
    public class ExprType
    {
        public const int NONE = 0;
        public const int ASSIGN = 1;
        public const int BINARY = 2;
        public const int CALL = 3;
        public const int GET = 4;
        public const int GROUPING = 5;
        public const int LITERAL = 6;
        public const int LOGICAL = 7;
        public const int SET = 8;
        public const int SUPER = 9;
        public const int THIS = 10;
        public const int UNARY = 11;
        public const int VARIABLE = 12;
    }
}