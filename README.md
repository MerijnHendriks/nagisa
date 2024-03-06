# Lox.Compiler

An attempt at implementing Lox in C# 3.0.

## Usage

- build: `dotnet build`
- test: `dotnet test`
- run: `dotnet run --project Lox.Compiler.App -- program.lox`

## Goals

- Easily embeddable
- Easy-to-port-over code (to other programming languages as well)

## FAQ

> Q: Why use such an old language version of C#?

A: This makes it easier to provide compatibility for projects depending on much
   older dotnet versions, such as Unity 5 games. It also eases translating the
   code to another language, for example Javascript.

> Q: Why are you using MSTest v2 instead of NUnit or xUnit

While `NUnit` and `xUnit` are both excellent testing frameworks, `MSTest v2`
has the backing and the reliability garuantee from Microsoft.

> Q: Is an older version of C# supported for testing?

A: Yes! If you need support for `.NET Framework 4.5`, use the following:

```xml
<!-- .NET Framework v4.5 compatible MSTest v2 -->
<ItemGroup Condition="'$(TargetFramework)' == 'net45'">
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.3.3" />
  <PackageReference Include="MSTest.TestAdapter" Version="2.2.10" />
  <PackageReference Include="MSTest.TestFramework" Version="2.2.10" />
</ItemGroup>
```

Any version lower is not supported by MSTest v2 however, you would need to
convert the tests to NUnit.
