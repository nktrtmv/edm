namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

public sealed class DiscriminatorTypeAttribute<T>
    : DiscriminatorTypeAttributeAbstract where T : Enum
{
    public override Type GetDiscriminatorType()
    {
        var result = typeof(T);

        return result;
    }
}
