using System;

namespace Lox.Optional
{
    public class Some<T> : Option<T>
        where T : class
    {
        protected Some(T value)
        {
            this._value = value;
        }
    }
}