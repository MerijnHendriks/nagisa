# Architecture

## Code conventions

- If you use something part of a member, use the `this` keyword.
- Only use `mscorlib`, `System` and `System.Generic.Collection` types.
- Do NOT use LINQ
  - Not supported by Lox
  - It's 3-5x slower than hand-written loops
  - If you need LINQ, consider rethinking your approach (does a simpler system work too?)
- Do NOT use `foreach`
  - Not supported by Lox
  - It's 2-5x slower than `for` on .NET 7.0 and older
- Do NOT use language-specific features unsupported by Lox
  - `static`
  - `enum`
  - method overloading
- Prefer inheritance over composition
- Use generics only where mandatory
- Use polymorphism where mandatory

## Scanner

Both `Token` and `SourcePosition` use a combination of `File` and `Index` to
give them an unique matching ID. For both instances, `File` is the source file
it originated from (exp. `./MyFilder/MyFile.lox`) and the `Index` is the index
of the scanner's iterator where the token was encountered.

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
    - `class`
    - `interface<T>`
  - `System`
    - `Exception`
  - `System.Generic.Collections`
    - `List<T>`

## FAQ

> Q: Why target .NET Framework 2.0 and .NET Standard 1.0?

- Enforcing a a minimal subset of the language makes it easy to to reason with
  the code
  - .NET Framework 2.0 removes much of the language's syntactic sugar.
  - .NET Standard 1.0 removes the .NET Framework and runtime specific APIs.
- Enforces self-reliance instead of using external packages.
- Enables support for Unity Engine (2017.4 and older).

> Q: Why `class` and not `struct` / `enum`?

One of the goals is to make the code relatively easy to port over to other languages.

- Structs have some odd rules in C# and not supported in languages like Lox/JS/Python
- Enums (as C-like constructs) are not suppored in languages like JS/Python

> Q: Why MSTest v2 over \<_insert unit testing framework here_>

Reliability is the top priority for me. A project written by Microsoft is less
prone to hostile maintainers (see Activismware on NPM and Ransomware in Moq),
more likely to receive extended support and also has one of the least
third-party dependencies (only `Newtonsoft.Json`) compared to other options.

> Q: Is an older version of .NET Framework supported for `Lox.Compiler.Tests`?

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