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
    - `class`
    - `interface<T>`
  - `System`
    - `Exception`
  - `System.Generic.Collections`
    - `List<T>`

## FAQ

> Q: Why target .NET Framework 2.0 and .NET Standard 1.0?

- .NET Framework 2.0 removes much of the language's syntactic sugar.
- .NET Standard 1.0 removes the .NET Framework and runtime specific APIs.

Those combined restrict the language's subset to a level that it becomes easy
to reason with the code, and enforces self-reliance.

It also enables support for Unity Engine (2017.4 and older).

> Q: Why MSTest v2 over \<_insert unit testing framework here_>

Reliability is the top priority for me. A project written by Microsoft is less
prone to hostile maintainers (see Activismware on NPM and Ransomware in Moq).
It also has one of the least thrird-party dependencies (only `Newtonsoft.Json`)
compared to other frameworks.

> Q: Is an older version of .NET Framework supported for testing?

Yes! If you need to integrate the tests in a project targeting `net45`, use the
following package versions in `Lox.Compiler.Tests`:

```xml
<!-- .NET Framework v4.5 compatible MSTest v2 -->
<ItemGroup Condition="'$(TargetFramework)' == 'net45'">
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.3.3" />
  <PackageReference Include="MSTest.TestAdapter" Version="2.2.10" />
  <PackageReference Include="MSTest.TestFramework" Version="2.2.10" />
</ItemGroup>
```