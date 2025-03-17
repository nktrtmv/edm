namespace Edm.Document.Classifier.Domain.Extensions;

public static class CollectionExtensions
{
    public static bool IsAllUnique<T>(this ICollection<T> collection) where T : IComparable<T>
    {
        var isUnique = collection.Count == collection.Distinct().Count();

        return isUnique;
    }

    public static ICollection<T> ThrowIfNonAllUnique<T>(this ICollection<T> collection, Func<string> getMessageFunc) where T : IComparable<T>
    {
        if (!collection.IsAllUnique())
        {
            throw new ApplicationException(getMessageFunc());
        }

        return collection;
    }

    public static ICollection<T> ThrowIfAnyDefault<T>(this ICollection<T> collection, Func<string> getMessageFunc)
    {
        if (collection.Any(c => c == null || c.Equals(default(T))))
        {
            throw new ApplicationException(getMessageFunc());
        }

        return collection;
    }
}
