namespace Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterTo
{
    public static string ToString<T>(ConcurrencyToken<T> concurrencyToken)
    {
        var result = concurrencyToken.Value.Value.ToString(ConcurrencyToken<T>.OutputStringFormat);

        return result;
    }

    public static DateTime ToDateTime<T>(ConcurrencyToken<T> concurrencyToken)
    {
        var result = UtcDateTimeConverterTo.ToDateTime(concurrencyToken.Value);

        return result;
    }
}
