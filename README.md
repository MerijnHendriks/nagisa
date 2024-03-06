# Lox.Compiler

An attempt at implementing Lox in C# 2.0.

## Usage

- build: `dotnet build`
- test: `dotnet test`
- run: `dotnet run --project Lox.Compiler.App -- program.lox`

## Goals

- Easily embeddable
- Easy-to-port-over code (to other programming languages as well)

## TODO

- Scanner is **BROKEN**
  - `!=`, `+=`, `-=`, `*=`, `/=` do not match properly