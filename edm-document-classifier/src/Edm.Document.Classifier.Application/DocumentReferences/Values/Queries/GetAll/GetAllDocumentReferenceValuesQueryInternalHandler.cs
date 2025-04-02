using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllDocumentReferenceValuesQueryInternalHandler(IDocumentReferenceValueRepository documentReferenceValueRepository)
    : IRequestHandler<GetAllDocumentReferenceValuesQueryInternal, GetAllDocumentReferenceValuesQueryResponseInternal>
{
    public async Task<GetAllDocumentReferenceValuesQueryResponseInternal> Handle(
        GetAllDocumentReferenceValuesQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        var queryParams = new GetAllDocumentReferenceTypesQueryParams(request.Search, request.Limit, request.Skip, []);

        ReferenceValue[] referenceValues = await documentReferenceValueRepository.GetAll(referenceType, queryParams, showHidden: true, cancellationToken);

        GetAllDocumentReferenceValuesQueryResponseInternal result = GetAllDocumentReferenceValuesQueryResponseInternalConverter.FromDomain(referenceValues);

        return result;
    }
}
