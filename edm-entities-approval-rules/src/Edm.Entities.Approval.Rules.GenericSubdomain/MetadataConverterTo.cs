namespace Edm.Entities.Approval.Rules.GenericSubdomain;

public static class MetadataConverterTo
{
    public static string ToString<T>(Metadata<T> metadata)
    {
        string result = metadata.Value;

        return result;
    }
}
