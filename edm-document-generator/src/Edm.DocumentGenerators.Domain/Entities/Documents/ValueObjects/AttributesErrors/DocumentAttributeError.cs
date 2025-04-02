using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;

public sealed class DocumentAttributeError
{
    public DocumentAttributeError(Id<DocumentAttribute> attributeId, string message)
    {
        AttributeId = attributeId;
        Message = message;
    }

    public Id<DocumentAttribute> AttributeId { get; }
    public string Message { get; }

    public override string ToString()
    {
        return $"{{ Id: '{AttributeId}', Message: {Message} }}";
    }
}
