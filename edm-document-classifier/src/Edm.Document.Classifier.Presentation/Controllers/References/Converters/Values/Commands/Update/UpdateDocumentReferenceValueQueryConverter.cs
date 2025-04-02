using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Update;

internal static class UpdateDocumentReferenceValueCommandConverter
{
    public static UpdateDocumentReferenceValueCommandInternal ToInternal(UpdateDocumentReferenceValueCommand command)
    {
        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(command.Value.ReferenceType);

        Id<ReferenceValueInternal> id = IdConverterFrom<ReferenceValueInternal>.FromString(command.Value.Id);

        Id<ReferenceValueInternal>? newId = string.IsNullOrWhiteSpace(command.Value.NewId)
            ? null
            : IdConverterFrom<ReferenceValueInternal>.FromString(command.Value.NewId);

        ConcurrencyToken<ReferenceValueInternal> concurrencyToken = ConcurrencyTokenConverterFrom<ReferenceValueInternal>.FromString(command.ConcurrencyToken);

        var result = new UpdateDocumentReferenceValueCommandInternal(
            currentUserId,
            referenceType,
            id,
            newId,
            command.Value.DisplayValue,
            command.Value.DisplaySubValue,
            command.Value.IsHidden,
            concurrencyToken
            );

        return result;
    }
}
