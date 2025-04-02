namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

public abstract class DiscriminatorTypeAttributeAbstract : Attribute
{
    public abstract Type GetDiscriminatorType();
}
