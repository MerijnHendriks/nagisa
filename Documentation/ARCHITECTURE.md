# Architecture

## Code conventions

- If you use something part of a member, use the `this` keyword.
- Do not use composition, only inheritance.
- Only use the following type namespaces:
  - `mscorlib`
  - `System`
  - `System.Generic.Collection`
  - `Microsoft.VisualStudio.TestTools.UnitTesting`
- Only use the following statements:
  - `if`
  - `else`
  - `switch`
  - `case`
  - `default`
  - `while`
  - `for`
  - `break`
  - `continue`
  - `new`
- Only use the following types:
  - `mscorlib`
    - `int`
    - `char`
    - `char[]`
    - `string`
    - `string[]`
    - `class`
  - `System`
    - `Exception`
  - `System.Generic.Collections`
    - `List<T>`

- Do NOT use the following language features:
  - `enum` (use `int`/`string` table instead)
  - method overloading
  - `++` / `--`

## Dependencies

The following C# versions and runtimes are used:

**Project**      | **C# version** | **Runtime**
-----------------| -------------- | -----------------------------------
Nagisa.Lox      | C# 2.0         | `net20`, `netstandard1.0`, `net8.0`
Nagisa.Lox       | C# 2.0         | `net20`, `netstandard1.0`, `net8.0`
Nagisa.Lox.App   | C# 3.0         | `net8.0`
Nagisa.Lox.Tests | C# 3.0         | `net8.0`

## Lexing

### Scanner

Both `Token` and `SourcePosition` use a combination of `File` and `Index` to
give them an unique matching ID.

- `File` is the source file it originated from (exp. `./MyFolder/MyFile.lox`)
- `Index` is the index of the scanner's iterator where the token was
  encountered.
