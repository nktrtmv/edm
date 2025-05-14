namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Swagger.Attributes;

public abstract class DiscriminatorTypeAttributeAbstract : Attribute
{
    public abstract Type GetDiscriminatorType();
}
