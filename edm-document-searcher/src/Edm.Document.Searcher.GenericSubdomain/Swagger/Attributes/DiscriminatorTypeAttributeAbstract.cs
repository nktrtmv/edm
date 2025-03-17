namespace Edm.Document.Searcher.GenericSubdomain.Swagger.Attributes;

public abstract class DiscriminatorTypeAttributeAbstract : Attribute
{
    public abstract Type GetDiscriminatorType();
}
