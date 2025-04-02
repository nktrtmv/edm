using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Create;

internal static class CreateDocumentReferenceTypeCommandConverter
{
    public static CreateDocumentReferenceTypeCommandInternal ToInternal(CreateDocumentReferenceTypeCommand command)
    {
        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(command.Type.ReferenceType);

        Id<DocumentReferenceTypeId>[] parentIds = command.Type.ParentReferenceTypes.Select(ReferenceTypeIdConverter.FromDto).ToArray();

        var result = new CreateDocumentReferenceTypeCommandInternal(
            command.Type.DomainId,
            referenceType,
            currentUserId,
            command.Type.DisplayName,
            parentIds
            );

        return result;
    }
}
