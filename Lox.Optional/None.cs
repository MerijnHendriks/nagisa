using System;

namespace Lox.Optional
{
    public class None<T> : Option<T>
        where T : class
    {
        protected None() : base()
        {
        }
    }
}