using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllDocumentReferenceTypesQueryInternalHandler(IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    : IRequestHandler<GetAllDocumentReferenceTypesQueryInternal, GetAllDocumentReferenceTypesQueryResponseInternal>
{
    public async Task<GetAllDocumentReferenceTypesQueryResponseInternal> Handle(
        GetAllDocumentReferenceTypesQueryInternal request,
        CancellationToken cancellationToken)
    {
        DomainId? domainId = string.IsNullOrWhiteSpace(request.DomainId) ? null : DomainId.Parse(request.DomainId);

        var queryParams = new GetAllDocumentReferenceTypesQueryParams(request.Search, request.Limit, request.Skip, []);

        ReferenceType[] references = await documentReferenceTypeRepository.GetAll(domainId, queryParams, cancellationToken);

        var result = GetAllDocumentReferenceTypesQueryResponseInternalConverter.FromDomain(references);

        return result;
    }
}
