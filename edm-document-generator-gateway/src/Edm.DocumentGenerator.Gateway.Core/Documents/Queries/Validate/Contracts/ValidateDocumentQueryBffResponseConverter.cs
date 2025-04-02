using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;
using Edm.DocumentGenerator.Gateway.Core.Validators;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;

internal static class ValidateDocumentQueryBffResponseConverter
{
    internal static ValidateDocumentQueryBffResponse FromInternal(
        ValidateDocumentQueryResponse response,
        List<DocumentAttributeError> validationErrors)
    {
        DocumentValidationResultBff[] documentValidatorsValidationResults =
            response.DocumentValidatorsValidationResults.Select(DocumentValidationResultBffConverter.ToBff).ToArray();

        CollectionQueryResponse<DocumentValidationResultBff> documentValidatorsValidationResultsCollection =
            CollectionQueryResponseConverter.ToBff(documentValidatorsValidationResults);

        var result = new ValidateDocumentQueryBffResponse
        {
            DocumentValidatorsValidationResults = documentValidatorsValidationResultsCollection,
            AttributesWarnings = validationErrors,
            DocumentWarnings = response.DocumentErrors.Errors.ToList()
        };

        return result;
    }
}
