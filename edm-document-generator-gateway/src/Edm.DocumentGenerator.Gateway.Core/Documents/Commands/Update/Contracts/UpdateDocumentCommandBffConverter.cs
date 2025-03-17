using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts;

internal static class UpdateDocumentCommandBffConverter
{
    public static UpdateDocumentCommand ToDto(UpdateDocumentCommandBff commandBff, string userId)
    {
        var document = DocumentBareBffConverter.ToUpdateParametersDto(
            commandBff.Document,
            commandBff.StatusTransitionParametersValues);

        var documentId = commandBff.Document.Id;

        var concurrencyToken = commandBff.Document.ConcurrencyToken;

        var command = new UpdateDocumentCommand
        {
            DocumentId = documentId,
            Parameters = document,
            CurrentUserId = userId,
            ConcurrencyToken = concurrencyToken
        };

        return command;
    }
}
