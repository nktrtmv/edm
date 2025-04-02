using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Create;

internal static class CreateDocumentReferenceValueCommandConverter
{
    public static CreateDocumentReferenceValueCommandInternal ToInternal(CreateDocumentReferenceValueCommand command)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(command.Value.ReferenceType);

        Id<ReferenceValueInternal>? id = string.IsNullOrWhiteSpace(command.Value.Id)
            ? null
            : IdConverterFrom<ReferenceValueInternal>.FromString(command.Value.Id);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new CreateDocumentReferenceValueCommandInternal(
            currentUserId,
            referenceType,
            id,
            command.Value.DomainId,
            command.Value.DisplayValue,
            command.Value.DisplaySubValue,
            command.Value.IsHidden);

        return result;
    }
}
