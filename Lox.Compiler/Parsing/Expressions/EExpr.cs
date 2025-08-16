namespace Lox.Compiler.Parsing.Expressions
{
    public enum EExpr
    {
        NONE = 0,
        ASSIGN,
        BINARY,
        CALL,
        GET,
        GROUPING,
        LITERAL,
        LOGICAL,
        SET,
        SUPER,
        THIS,
        UNARY,
        VARIABLE
    }
}