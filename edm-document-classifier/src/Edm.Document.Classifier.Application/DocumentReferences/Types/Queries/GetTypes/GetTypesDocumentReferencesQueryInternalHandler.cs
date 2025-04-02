using Edm.Document.Classifier.Application.DocumentReferences.Services;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes;

[UsedImplicitly]
internal sealed class GetTypesDocumentReferencesQueryInternalHandler
    : IRequestHandler<GetTypesDocumentReferencesQueryInternal, GetTypesDocumentReferencesQueryResponseInternal>
{
    public GetTypesDocumentReferencesQueryInternalHandler(
        IEnumerable<DocumentReferenceService> references,
        IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    {
        _documentReferenceTypeRepository = documentReferenceTypeRepository;

        Types = references
            .Select(r => r.Type)
            .Select(DocumentReferenceTypeInternalConverter.FromDomain)
            .ToArray();
    }


    private DocumentReferenceTypeInternal[] Types { get; }

    private readonly IDocumentReferenceTypeRepository _documentReferenceTypeRepository;

    public async Task<GetTypesDocumentReferencesQueryResponseInternal> Handle(GetTypesDocumentReferencesQueryInternal request, CancellationToken cancellationToken)
    {
        GetAllDocumentReferenceTypesQueryParams queryParams = GetAllDocumentReferenceTypesQueryParams.Instance;

        ReferenceType[] references = await _documentReferenceTypeRepository.GetAll(null, queryParams, cancellationToken);

        DocumentReferenceTypeInternal[] referenceTypes = references.Select(DocumentReferenceTypeInternalConverter.FromDomain).ToArray();

        DocumentReferenceTypeInternal[] types = Types.Concat(referenceTypes)
            .GroupBy(x => x.Id.Value)
            .Select(x => x.Last())
            .ToArray();

        var result = new GetTypesDocumentReferencesQueryResponseInternal(types);

        return result;
    }
}
