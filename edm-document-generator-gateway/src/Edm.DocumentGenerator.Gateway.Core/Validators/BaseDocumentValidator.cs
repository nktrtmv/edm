using System.Diagnostics.CodeAnalysis;

using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.Validators;

[SuppressMessage("ReSharper", "ArrangeMethodOrOperatorBody")]
public abstract class BaseDocumentValidator : IDocumentValidator
{
    protected abstract DocumentCondition ValidationCondition { get; }

    public bool CanValidate(
        string domainId,
        IRoleAdapter roleAdapter,
        DocumentEnrichedData documentEnrichedData,
        ValidateDocumentQueryResponse document) => ValidationCondition(domainId, roleAdapter, document);

    public abstract (bool IsValid, List<DocumentAttributeError>? Errors) Validate(
        string domainId,
        IRoleAdapter roleAdapter,
        DocumentEnrichedData documentEnrichedData,
        ValidateDocumentQueryResponse document);
}
