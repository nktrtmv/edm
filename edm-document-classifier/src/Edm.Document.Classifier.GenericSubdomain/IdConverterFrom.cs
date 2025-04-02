namespace Edm.Document.Classifier.GenericSubdomain;

public static class IdConverterFrom<T>
{
    public static Id<T> FromString(string id)
    {
        var result = new Id<T>(id);

        return result;
    }

    public static Id<T> FromGuid(Guid id)
    {
        Id<T> result = FromString(id.ToString());

        return result;
    }

    public static Id<T> From<TSource>(Id<TSource> id)
    {
        Id<T> result = FromString(id.Value);

        return result;
    }

    public static Id<T> FromInt(int id)
    {
        Id<T> result = FromString(id.ToString());

        return result;
    }

    public static Id<T> FromEnum(Enum id)
    {
        Id<T> result = FromString(Convert.ToInt32(id).ToString());

        return result;
    }

}
