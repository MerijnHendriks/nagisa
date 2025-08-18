# Nagisa (汀) <div style="float:right;">🌊🏝️</div>

> Lasciate ogne speranza, voi ch'intrate.

Generic interpreter infrastructure in a very limited subset of C# 2.
Works with almost every C# version and .NET framework.

**Project**        | **Description**
------------------ | -----------------------------------------------
`Nagisa.Core`      | Generic interpreter infrastructure.
`Nagisa.Lox`       | A C# implementation of Lox.
`Nagisa.Lox.App`   | A standalone C# interpreter for Lox.
`Nagisa.Lox.Tests` | Tests to validate the C# implementation of Lox.

**Usage** | **Command**
--------- | ------------------------------------------------------
Build     | `dotnet build`
Test      | `dotnet test`
Run       | `dotnet run --project Nagisa.Lox.App -- program.lox`

## Goals

- Support Lox standard
  - Grammer: Appendix A1 conforming
  - Features: none of the challenges

## Requirements

- Visual Studio Code
- .NET 8 SDK

## Documentation

See `Documentation/`.
