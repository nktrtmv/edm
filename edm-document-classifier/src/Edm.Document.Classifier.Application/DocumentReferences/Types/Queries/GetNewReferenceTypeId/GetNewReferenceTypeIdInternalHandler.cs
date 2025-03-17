using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId;

[UsedImplicitly]
internal sealed class GetNewReferenceTypeIdInternalHandler(IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    : IRequestHandler<GetNewReferenceTypeIdQueryInternal, GetNewReferenceTypeIdQueryResponseInternal>
{
    private const int InitReferenceId = 100_000;

    public async Task<GetNewReferenceTypeIdQueryResponseInternal> Handle(
        GetNewReferenceTypeIdQueryInternal request,
        CancellationToken cancellationToken)
    {
        int? lastReferenceTypeId = await documentReferenceTypeRepository.GetLastReferenceTypeId(cancellationToken);

        int newReferenceTypeId = (lastReferenceTypeId ?? InitReferenceId) + 1;

        GetNewReferenceTypeIdQueryResponseInternal result = GetNewReferenceTypeIdQueryResponseInternalConverter.FromDomain(newReferenceTypeId);

        return result;
    }
}
