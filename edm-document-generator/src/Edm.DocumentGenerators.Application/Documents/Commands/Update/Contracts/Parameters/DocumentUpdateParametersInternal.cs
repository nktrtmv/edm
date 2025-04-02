using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;

public sealed class DocumentUpdateParametersInternal
{
    public DocumentUpdateParametersInternal(
        Id<DocumentStatusInternal> statusId,
        DocumentAttributeValueInternal[] attributesValues,
        DocumentStatusTransitionParameterValueInternal[] statusTransitionParametersValues)
    {
        StatusId = statusId;
        AttributesValues = attributesValues;
        StatusTransitionParametersValues = statusTransitionParametersValues;
    }

    internal Id<DocumentStatusInternal> StatusId { get; }
    internal DocumentAttributeValueInternal[] AttributesValues { get; }
    internal DocumentStatusTransitionParameterValueInternal[] StatusTransitionParametersValues { get; }
}
