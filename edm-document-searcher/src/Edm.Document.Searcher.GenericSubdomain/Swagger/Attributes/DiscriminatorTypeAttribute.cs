namespace Edm.Document.Searcher.GenericSubdomain.Swagger.Attributes;

public sealed class DiscriminatorTypeAttribute<T>
    : DiscriminatorTypeAttributeAbstract where T : Enum
{
    public override Type GetDiscriminatorType()
    {
        Type result = typeof(T);

        return result;
    }
}
