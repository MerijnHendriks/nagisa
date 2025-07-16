namespace Lox.Compiler.Lexing
{
    public sealed class TokenType
    {
        public const int INVALID = -1;              // ERROR
        public const int END_OF_FILE = 0;           // EOF
        public const int END_OF_LINE = 1;           // \r or \n or \r\n
        public const int DOT = 2;                   // .
        public const int COMMA = 3;                 // ,
        public const int SEMICOLON = 4;             // ;
        public const int LEFT_CURLY = 7;            // {
        public const int RIGHT_CURLY = 8;           // }
        public const int LEFT_CIRCLE = 9;           // (
        public const int RIGHT_CIRCLE = 10;         // )
        public const int LEFT_ARROW = 11;           // <
        public const int RIGHT_ARROW = 12;          // >
        public const int ASSIGN = 13;               // =
        public const int NOT = 14;                  // !
        public const int PLUS = 15;                 // +
        public const int MINUS = 16;                // -
        public const int STAR = 17;                 // *
        public const int SLASH = 18;                // /
        public const int EQUAL = 19;                // ==
        public const int NOT_EQUAL = 20;            // !=
        public const int LESS_EQUAL = 21;           // <=
        public const int GREATER_EQUAL = 22;        // >=
        public const int ADD_ASSIGN = 23;           // +=
        public const int SUBSTRACT_ASSIGN = 24;     // -=
        public const int MULTIPLY_ASSIGN = 25;      // *=
        public const int DIVIDE_ASSIGN = 26;        // /=
        public const int IDENTIFIER = 27;           // foo
        public const int NUMBER = 28;               // 1 or 1.0
        public const int STRING = 29;               // "Hello; world!"
        public const int TRUE = 30;                 // true
        public const int FALSE = 31;                // false
        public const int NIL = 32;                  // nil
        public const int THIS = 33;                 // this
        public const int SUPER = 34;                // super
        public const int VAR = 35;                  // var
        public const int FUN = 36;                  // fun
        public const int CLASS = 37;                // class
        public const int AND = 38;                  // and; &&
        public const int OR = 39;                   // or; ||
        public const int IF = 40;                   // if
        public const int ELSE = 41;                 // else
        public const int WHILE = 42;                // while
        public const int FOR = 43;                  // for
        public const int CONTINUE = 44;             // continue
        public const int BREAK = 45;                // break
        public const int RETURN = 46;               // return
        public const int PRINT = 47;                // print    (TODO: move this to VM bindings or standard library)
        public const int LINE_COMMENT = 48;         // // hello; world!
        public const int TAB = 49;                  // \t
        public const int WHITESPACE = 50;           //
    }
}
