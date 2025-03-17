using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public abstract record AllowedAttributeCondition;

public sealed record StringAllowedAttributeCondition : AllowedAttributeCondition;

public sealed record DateAllowedAttributeCondition : AllowedAttributeCondition;

public sealed record NumberAllowedAttributeCondition : AllowedAttributeCondition;

public sealed record AttachmentAllowedAttributeCondition : AllowedAttributeCondition;

public sealed record BooleanAllowedAttributeCondition : AllowedAttributeCondition;

public sealed record ReferenceAllowedAttributeCondition : AllowedAttributeCondition
{
    private ReferenceAllowedAttributeCondition()
    {
    }

    public DocumentReferenceTypeId Value { get; private init; }

    public static ReferenceAllowedAttributeCondition Parse(DocumentReferenceTypeId id)
    {
        if (id == DocumentReferenceTypeId.None)
        {
            throw new ApplicationException("DocumentReferenceTypeId value can't be none");
        }

        return new ReferenceAllowedAttributeCondition
        {
            Value = id
        };
    }
}
