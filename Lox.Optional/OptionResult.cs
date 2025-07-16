using System;

namespace Lox.Optional
{
    public delegate void OptionResult<T>(T value)
        where T : class;
}