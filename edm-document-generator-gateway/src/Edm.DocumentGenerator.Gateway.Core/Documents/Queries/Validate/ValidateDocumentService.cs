using System.Diagnostics.CodeAnalysis;

using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts.AttributesErrors;
using Edm.DocumentGenerator.Gateway.Core.Validators;
using Edm.DocumentGenerator.Gateway.Core.Validators.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate;

[SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
public sealed class ValidateDocumentService(
    IRoleAdapter roleAdapter,
    DocumentsService.DocumentsServiceClient documentsServiceClient,
    IEnumerable<IDocumentValidatorEnricher> validatorEnrichers,
    IEnumerable<IDocumentValidator> validators)
{
    public async Task<ValidateDocumentQueryBffResponse> Validate(
        ValidateDocumentQueryBff request,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var validateResponse = await GetValidateResponse(request, cancellationToken);

        var enrichedData = new DocumentEnrichedData();

        var enrichers = validatorEnrichers
            .Where(x => x.CanEnrich(request.Document.DomainId, roleAdapter, validateResponse))
            .ToList();

        await Task.WhenAll(enrichers.Select(x => x.Enrich(request.Document.DomainId, roleAdapter, enrichedData, validateResponse, cancellationToken)));

        var validatorToValidate = validators.Where(x => x.CanValidate(request.Document.DomainId, roleAdapter, enrichedData, validateResponse)).ToList();

        var validationErrors = validatorToValidate.Select(x => x.Validate(request.Document.DomainId, roleAdapter, enrichedData, validateResponse))
            .Where(x => x is { IsValid: false, Errors: not null })
            .SelectMany(x => x.Errors!)
            .Concat(validateResponse.DocumentErrors.AttributesErrors.Select(DocumentAttributeErrorBffConverter.FromDto))
            .ToList();

        ValidateDocumentQueryBffResponse result = ValidateDocumentQueryBffResponseConverter.FromInternal(validateResponse, validationErrors);

        return result;
    }

    private async Task<ValidateDocumentQueryResponse> GetValidateResponse(ValidateDocumentQueryBff query, CancellationToken cancellationToken)
    {
        ValidateDocumentQuery request = ValidateDocumentQueryBffConverter.ToInternal(query);

        ValidateDocumentQueryResponse result = await documentsServiceClient.ValidateAsync(request, cancellationToken: cancellationToken);

        return result;
    }
}
