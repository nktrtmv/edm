using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;

internal static class ValidateDocumentQueryBffConverter
{
    internal static ValidateDocumentQuery ToInternal(ValidateDocumentQueryBff query)
    {
        var parameters = DocumentBareBffConverter.ToValidationParametersDto(query.Document);

        var result = new ValidateDocumentQuery
        {
            DomainId = query.Document.DomainId,
            DocumentId = query.Document.Id,
            Parameters = parameters
        };

        return result;
    }
}
