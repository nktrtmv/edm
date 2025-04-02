namespace Edm.DocumentGenerators.GenericSubdomain;

public sealed class Change<T>
{
    public Change(T from, T to)
    {
        From = from;
        To = to;
    }

    public T From { get; }
    public T To { get; }
}
