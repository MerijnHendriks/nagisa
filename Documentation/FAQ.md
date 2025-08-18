# Frequently Asked Questions (FAQ)

> Q: Why target `C# 2.0`, `.NET Framework 2.0` and `.NET Standard 1.0`?

A: I wanted the smallest featureset of the language and runtime. That way it
makes it easier for me to reason with the code, and forces me to think how I
can write it as simple as possible.

To be more specific:

- `C# 2.0`: resticts language features
- `.NET Framework 2.0`: removes much of the language's syntactic sugar.
- `.NET Standard 1.0`: removes framework, platform and runtime specific APIs.

> Q: Why `class` and not `enum`?
>
> Q: Why `+= 1` / `-= 1` and not `++` / `--`?

I want the code to be easily portable to other languages, such as Lox. Some
languages like `TS`, `Lox` and such do not implement `enum` but do implement
`class`. Same for `++` / `--`.

> Q: Why MSTest v2 over \<_insert unit testing framework here_>
>
> Q: Why Microsoft.CodeCoverage over <_insert code coverage collector here_>

It seems to do the job pretty well, it's decently documented and well
supported.

> Q: Is an older version of .NET Framework supported for `Nagisa.Lox.Tests`?

Yes! If you need to integrate the tests in a project targeting `net45`, add
the following to `Nagisa.Lox.Tests`:

```xml
<!-- .NET Framework v4.5 compatible MSTest v2 -->
<ItemGroup Condition="'$(TargetFramework)' == 'net45'">
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.3.3" />
  <PackageReference Include="MSTest.TestAdapter" Version="2.2.10" />
  <PackageReference Include="MSTest.TestFramework" Version="2.2.10" />
</ItemGroup>
```

> Q: Are the configured tools supported on .NET Framework?

Yes! If you run them through the .NET 8.0 SDK.
