namespace Lox.Optional
{
    public delegate TResult OptionMap<T, TResult>(T content)
        where T : class
        where TResult : class;
}