using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;

public sealed class DocumentValidateParametersInternal
{
    public DocumentValidateParametersInternal(Id<DocumentStatusInternal> statusId, DocumentAttributeValueInternal[] attributesValues)
    {
        StatusId = statusId;
        AttributesValues = attributesValues;
    }

    internal Id<DocumentStatusInternal> StatusId { get; }
    internal DocumentAttributeValueInternal[] AttributesValues { get; }
}
