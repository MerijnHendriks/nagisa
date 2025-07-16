# Fox

## Goals

- Bootstrap itself
- Able to generate to the following languages:
  - AssemblyScript
  - C 99
  - C++ 03
  - .NET Framework 2.0 (csharp 2)
  - Python 3.4
  - Rust (using GC)
  - TypeScript 2.0.0 (es6)
- Optionally
  - CIL 2
  - Java 8
  - JVM 8 bytecode
  - Kotlin
  - LLVM IR
  - WASM
  - x86_64 assembly

## Target

A simple meta programming language that's quick to write code in, simple to
learn, only includes what's required and easy to embed / extend.

## Language

### Constructs

**Operator** | **Description**
------------ | ---------------
`+`          | Add
`+=`         | Add assign
`-`          | Minus
`-=`         | Minus assign
`*`          | Multiply
`*=`         | Multiply assign
`/`          | Divide
`/=`         | Divide assign
`%`          | Modulo
`%=`         | Modulo assign
`!`          | Negate
`!=`         | Not equal
`=`          | Assign
`==`         | Equals
`&&`         | And
`\|\|`       | Or
`<`          | Less
`<=`         | Less equal
`>`          | Greater
`>=`         | Greater equal

**Statement** | **C statement**
------------- | ---------------
`if`          | `if`
`else`        | `else`
`while`       | `while`
`for`         | `for`
`switch`      | `switch`
`case`        | `case`
`option<T>`   | ...

**Types** | **C type**
--------- | ---------------
`void`    | `void`
`number`  | `float64_t`
`char`    | `uint32_t`
`string`  | `uint32_[]`
`byte`    | `uint8_t`
`bool`    | `bool`
`func`    | function
`type`    | `struct`
`arr<T>`  | `T[]`

## Notes

> Why no `++` or `--` support?

Keeps the language simpler to port

> Why is `number` a `float64_t` instead of supplying different types?

Since this is a scripting language, I wanted to keep it's complexity as low as
possible to make it as simple to work with, but also easy to translate to other
languages.

TypeScript does not support different types unless you use AssemblyScript.

It also complicates comparisons. Do we need to report conversion warnings when
precision is lost? How many programmers actually understand how signed to
unsigned conversion works (and use it safely)?

> Why is `string` actually a `uint32_t[]` instead of a c-string (`char[]`)?

In c, `char` is an `int8_t`. But since the modern standard is unicode
(`uint32_t`), it doesn't fit neatly inside that.

You can use UTF-8 to calculate the codepoints but that means working directly
with strings would be a hassle to implement. I opted to go for the easiest
route at the expense of size.

> Why no `null`?

I want to see if I can avoid it where possible, `option<T>` seems like a nice
way to do it.
