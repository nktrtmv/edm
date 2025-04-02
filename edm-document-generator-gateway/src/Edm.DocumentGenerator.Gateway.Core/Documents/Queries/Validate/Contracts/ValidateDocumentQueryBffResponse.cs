using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;
using Edm.DocumentGenerator.Gateway.Core.Validators;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;

public sealed class ValidateDocumentQueryBffResponse
{
    public required CollectionQueryResponse<DocumentValidationResultBff> DocumentValidatorsValidationResults { get; init; }

    public required List<DocumentAttributeError> AttributesWarnings { get; init; }
    public required List<string> DocumentWarnings { get; init; }
}
