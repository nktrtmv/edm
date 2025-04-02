using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;

public sealed class DocumentValidateParameters
{
    public DocumentValidateParameters(
        Document document,
        Id<DocumentStatus> changedStatusId,
        DocumentAttributeValue[] attributesValues)
    {
        Document = document;
        ChangedStatusId = changedStatusId;
        AttributesValues = attributesValues;
    }

    internal Document Document { get; }
    internal Id<DocumentStatus> ChangedStatusId { get; }
    internal DocumentAttributeValue[] AttributesValues { get; }
}
