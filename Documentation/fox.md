# Fox

## Syntax grammer

```
program     → declaration* EOF ;

declaration → varDecl
            | statement ;

varDecl     → "var" IDENTIFIER ( "=" expression )? ";" ;

statement   → exprStmt
            | assignStmt
            | ifStmt
            | printStmt
            | returnStmt
            | whileStmt
            | block ;

exprStmt    → expression ";" ;
assignStmt  → IDENTIFIER ( "=" | "+=" | "-=" | "*=" | "/=" | "%=" )
              expression ;
ifStmt      → "if" "(" expression ")" statement
              ( "else" statement )? ;
printStmt   → "print" expression ";" ;
returnStmt  → "return" expression? ";" ;
whileStmt   → "while" "(" expression ")" statement ;
block       → "{" declaration* "}" ;

expression  → logic_or ;

logic_or    → logic_and ( "||" logic_and )* ;
logic_and   → equality ( "&&" equality )* ;
equality    → comparison ( ( "!=" | "==" ) comparison )* ;
comparison  → term ( ( ">" | ">=" | "<" | "<=" ) term )* ;
term        → factor ( ( "-" | "+" ) factor )* ;
factor      → unary ( ( "/" | "*" | "%" ) unary )* ;

unary       → ( "!" | "-" ) unary ;
primary     → "true" | "false" | "nil"
            | NUMBER | STRING | IDENTIFIER | "(" expression ")"

NUMBER      → DIGIT+ ( "." DIGIT+ )? ;
STRING      → "\"" <any char except "\"">* "\"" ;
IDENTIFIER  → ALPHA ( ALPHA | DIGIT )* ;
ALPHA       → "a" ... "z" | "A" ... "Z" | "_" ;
DIGIT       → "0" ... "9" ;
```