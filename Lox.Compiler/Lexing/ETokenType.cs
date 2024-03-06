namespace Lox.Compiler.Lexing
{
    public enum ETokenType
    {
        Invalid,            // ERROR
        EOF,                // end of file
        EOL,                // end of line
        Dot,                // .
        Comma,              // ,
        Semicolon,          // ;
        LeftSquare,         // [
        RightSquare,        // ]
        LeftCurly,          // {
        RightCurly,         // }
        LeftCircle,         // (
        RightCircle,        // )
        LeftArrow,          // <
        RightArrow,         // >
        Assign,             // =
        Not,                // !
        Plus,               // +
        Minus,              // -
        Star,               // *
        Slash,              // /
        Equal,              // ==
        NotEqual,           // !=
        LessEqual,          // <=
        GreaterEqual,       // >=
        AddAssign,          // +=
        SubstractAssign,    // -=
        MultiplyAssign,     // *=
        DivideAssign,       // /=
        Identifier,         // foo
        Number,     	    // 1 or 1.0
        String,             // "Hello, world!"
        True,               // true
        False,              // false
        Nil,                // nil
        This,               // this
        Super,              // super
        Variable,           // var
        Function,           // fun
        Class,              // class
        And,                // and, &&
        Or,                 // or, ||
        If,                 // if
        Else,               // else
        While,              // while
        For,                // for
        Continue,           // continue
        Break,              // break
        Return,             // return
        Print,              // print    (note: std lib function!)
        LineComment,        // // hello, world!
        Tab,                // \t
        Whitespace,         //

        BitShiftLeft,       // <<=
        BitShiftRight,      // >>=      
        BitwiseAnd,         // &
        BitwiseOr,          // |
        BitwiseXor,         // ^
        BitwiseComplement   // ~

    }
}