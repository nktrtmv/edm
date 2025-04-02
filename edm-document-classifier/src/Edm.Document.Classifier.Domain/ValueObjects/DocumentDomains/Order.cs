namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct Order
{
    public Order()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private Order(long n)
    {
        Value = n;
    }

    public long Value { get; private init; }

    public static Order Parse(long n)
    {
        var result = ParseOrNull(n);

        if (result is not { } value)
        {
            throw new ApplicationException("Order can't be null");
        }

        return value;
    }

    public static Order? ParseOrNull(long? n)
    {
        if (n is not { } value)
        {
            return null;
        }

        return new Order(value);
    }
}
