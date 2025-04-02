namespace Edm.DocumentGenerators.GenericSubdomain;

public static class ChangeConverter<T>
{
    public static Change<T> From<TSource>(Change<TSource> value, Func<TSource, T> converter)
    {
        T from = converter(value.From);

        T to = converter(value.To);

        var result = new Change<T>(from, to);

        return result;
    }
}
