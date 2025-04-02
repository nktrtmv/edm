using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Update.Contracts.Parameters;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Update;

internal static class UpdateDocumentCommandConverter
{
    internal static UpdateDocumentCommandInternal ToInternal(UpdateDocumentCommand command)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.FromString(command.DocumentId);

        DocumentUpdateParametersInternal parameters = DocumentUpdateParametersDtoConverter.ToInternal(command.Parameters);

        ConcurrencyToken<DocumentInternal> concurrencyToken = ConcurrencyTokenConverterFrom<DocumentInternal>.FromString(command.ConcurrencyToken);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new UpdateDocumentCommandInternal(documentId, parameters, concurrencyToken, currentUserId);

        return result;
    }
}
