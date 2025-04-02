using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentReferenceValueQueryInternalHandler(IDocumentReferenceValueRepository documentReferenceValueRepository)
    : IRequestHandler<GetDocumentReferenceValueQueryInternal, GetDocumentReferenceValueQueryResponseInternal>
{
    public async Task<GetDocumentReferenceValueQueryResponseInternal> Handle(
        GetDocumentReferenceValueQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        Id<ReferenceValue> id = IdConverterFrom<ReferenceValue>.From(request.Id);

        ReferenceValue referenceValue = await documentReferenceValueRepository.GetRequired(referenceType, id, cancellationToken);

        var result = GetDocumentReferenceValueQueryResponseInternalConverter.FromDomain(referenceValue);

        return result;
    }
}
