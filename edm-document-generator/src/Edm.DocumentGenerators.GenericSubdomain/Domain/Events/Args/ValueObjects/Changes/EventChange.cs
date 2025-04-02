namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

public sealed class EventChange<T>
{
    public EventChange(T from, T to)
    {
        From = from;
        To = to;
    }

    public T From { get; }
    public T To { get; }
}
