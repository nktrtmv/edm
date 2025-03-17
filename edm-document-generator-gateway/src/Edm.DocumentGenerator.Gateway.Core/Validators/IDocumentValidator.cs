using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.Validators;

public sealed record DocumentAttributeError(string AttributeId, string Message);

public interface IDocumentValidator
{
    bool CanValidate(
        string domainId,
        IRoleAdapter roleAdapter,
        DocumentEnrichedData documentEnrichedData,
        ValidateDocumentQueryResponse document);

    (bool IsValid, List<DocumentAttributeError>? Errors) Validate(
        string domainId,
        IRoleAdapter roleAdapter,
        DocumentEnrichedData documentEnrichedData,
        ValidateDocumentQueryResponse document);
}
