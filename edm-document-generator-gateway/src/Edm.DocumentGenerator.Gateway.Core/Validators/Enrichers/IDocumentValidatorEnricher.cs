// using System.Diagnostics.CodeAnalysis;
// using System.Reflection.Metadata;
//
// using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;
// using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;
// using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.References;
// using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;
//

using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.Validators.Enrichers;

public interface IDocumentValidatorEnricher
{
    Task Enrich(
        string domainId,
        IRoleAdapter roleAdapter,
        DocumentEnrichedData data,
        ValidateDocumentQueryResponse validateResponse,
        CancellationToken cancellationToken);

    bool CanEnrich(
        string domainId,
        IRoleAdapter roleAdapter,
        ValidateDocumentQueryResponse validateResponse);
}
