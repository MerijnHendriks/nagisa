# Architecture

## Code conventions

- If you use something part of a member, use the `this` keyword.
- Prefer inheritance over composition
- Only use the following type namespaces:
  - `mscorlib`
  - `System`
  - `System.Generic.Collection`
  - `Microsoft.VisualStudio.TestTools.UnitTesting`
- Do NOT use `foreach`
  - It's 2-5x slower than `for` on .NET 7.0 and older
- Do NOT use LINQ
  - It's 3-5x slower than hand-written loops
  - If you need LINQ, consider rethinking your approach (does something simpler
    work?)
- Do NOT use the following language features:
  - `enum` (use `int`/`string` table instead)
  - method overloading
  - `++` / `--`
- Only use the following when there are no better options:
  - `static`
  - `interface`
  - generics
  - polymorphism

## Dependencies

The following C# versions and runtimes are used:

**Project**        | **C# version** | **Runtime**
------------------ | -------------- | -----------------------------------
Lox.Compiler       | C# 2.0         | `net20`, `netstandard1.0`, `net9.0`
Lox.Compiler.App   | C# 3.0         | `net9.0`
Lox.Compiler.Tests | C# 3.0         | `net9.0`

The following types are referenced:

- Lox.Compiler
  - `mscorlib`
    - `int`
    - `char`
    - `char[]`
    - `string`
    - `string[]`
    - `class`
    - `interface<T>`
  - `System`
    - `Exception`
  - `System.Generic.Collections`
    - `List<T>`

## Lexing

### Scanner

Both `Token` and `SourcePosition` use a combination of `File` and `Index` to
give them an unique matching ID.

- `File` is the source file it originated from (exp. `./MyFolder/MyFile.lox`)
- `Index` is the index of the scanner's iterator where the token was
  encountered.

## FAQ

> - Why target .NET Framework 2.0 and .NET Standard 1.0?

They're used to enforce a minimal subset of the C# language and .NET runtimes.
This also encourages self-reliance over external package usage and improves
portability (example: Unity Engine 2017.4 and older). It is easier to upgrade
old code to a newer version than downgrading retroactively.

The following is reduced:

- C# 2.0: resticts language features
- .NET Framework 2.0: removes much of the language's syntactic sugar.
- .NET Standard 1.0: removes platform and runtime specific APIs.

> - Why `class` and not `struct` / `enum`?

One of the goals is to make the code relatively easy to port over to other
languages.

- Structs have some odd rules in C# and not supported in languages like
  Lox/JS/Python
- Enums (as C-like constructs) are not supported in languages like
  Javascript and Python (3.4 and older).

> - Why no `++` / `--`

Not all languages I want to port the project to support this.

> - Why MSTest v2 over \<_insert unit testing framework here_>
> - Why Microsoft.CodeCoverage over <_insert code coverage collector here_>

Reliability is the top priority for me. A project written by Microsoft is less
prone to hostile maintainers (see Activismware on NPM and Ransomware in Moq),
more likely to receive extended support and also has one of the least
third-party dependencies (only `Newtonsoft.Json`) compared to other options.

> - Is an older version of .NET Framework supported for `Lox.Compiler.Tests`?

Yes! If you need to integrate the tests in a project targeting `net45`, add
the following to `Lox.Compiler.Tests`:

```xml
<!-- .NET Framework v4.5 compatible MSTest v2 -->
<ItemGroup Condition="'$(TargetFramework)' == 'net45'">
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.3.3" />
  <PackageReference Include="MSTest.TestAdapter" Version="2.2.10" />
  <PackageReference Include="MSTest.TestFramework" Version="2.2.10" />
</ItemGroup>
```

If you need support for even older versions of .NET Framework, consider
migrating the tests to NUnit.

> - Are the configured tools supported on .NET Framework?

Yes! If you run them through the .NET 8.0 SDK.
