using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Update;

internal static class UpdateDocumentReferenceTypeCommandConverter
{
    public static UpdateDocumentReferenceTypeCommandInternal ToInternal(UpdateDocumentReferenceTypeCommand command)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(command.Reference.ReferenceType);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        Id<DocumentReferenceTypeId>[] parentIds = command.Reference.ParentReferenceTypes.Select(ReferenceTypeIdConverter.FromDto).ToArray();

        ConcurrencyToken<DocumentReferenceTypeInternal> concurrencyToken = ConcurrencyTokenConverterFrom<DocumentReferenceTypeInternal>.FromString(command.ConcurrencyToken);

        var result = new UpdateDocumentReferenceTypeCommandInternal(
            referenceType,
            command.Reference.DomainId,
            currentUserId,
            command.Reference.DisplayName,
            parentIds,
            concurrencyToken);

        return result;
    }
}
