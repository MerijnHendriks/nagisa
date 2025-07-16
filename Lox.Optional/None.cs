using System;

namespace Lox.Optional
{
    public class None<T> : OptionResult<T>
        where T : class
    {
        protected None()
        {
        }
    }
}