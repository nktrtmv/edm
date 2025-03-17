namespace Edm.Entities.Approval.Rules.GenericSubdomain;

public static class MetadataConverterFrom<T>
{
    public static Metadata<T> FromString(string value)
    {
        var result = new Metadata<T>(value);

        return result;
    }

    public static Metadata<T> From<TSourceMetadata>(Metadata<TSourceMetadata> metadata)
    {
        var result = new Metadata<T>(metadata.Value);

        return result;
    }
}
