# Architecture

...

## Dependencies

The following C# versions and runtimes are used:

**Project**        | **C# version** | **Runtime**
------------------ | -------------- | -----------------------------------
Lox.Compiler       | C# 2.0         | `net20`, `netstandard1.0`, `net8.0`
Lox.Compiler.App   | C# 3.0         | `net8.0`
Lox.Compiler.Tests | C# 3.0         | `net8.0`

The following types are referenced:

- Lox.Compiler
  - `mscorlib`
    - `int`
    - `char`
    - `char[]`
    - `string`
    - `string[]`
    - `enum`
    - `struct`
    - `class`
    - `interface`
    - `interface<T>`
  - `System`
    - `Exception`
  - `System.Generic.Collections`
    - `List<T>`

## FAQ

> Why target .NET Framework 2.0 and .NET Standard 1.0?

- .NET Framework 2.0 removes much of the language's syntactic sugar.
- .NET Standard 1.0 removes the .NET Framework specific APIs.

It restrict the language's subset to a level that it becomes easy to reason
with the code, and enforces self-reliance.

In addition, it makes supporting .NET Micro easier, and enables support for
Unity Engine

## TODO

- Remove unavailable APIs in TinyCLR (see [this](https://github.com/ghi-electronics/TinyCLR-Libraries))
- Remove unavailable APIs in nanoFramework (see [this](https://github.com/nanoframework/CoreLibrary/tree/main/nanoFramework.CoreLibrary/System))
- Remove generics (see [this](https://docs.ghielectronics.com/software/tinyclr/limitations.html))
  - Replace List<T> with ArrayList
  - Rework visitor pattern without generics