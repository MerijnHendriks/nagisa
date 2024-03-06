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

> Q: Why MSTest v2 over \<_insert unit testing framework here_>

Reliability is the top priority for me. A project written by Microsoft is less
prone to hostile maintainers (see Activismware on NPM and Ransomware in Moq),
more likely to receive extended support and also has one of the least
thrird-party dependencies (only `Newtonsoft.Json`) compared to other options.

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

If you need support for even older versions of .NET Framework, consider NUnit.