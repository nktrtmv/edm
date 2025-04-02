using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentReferenceTypeQueryInternalHandler(IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    : IRequestHandler<GetDocumentReferenceTypeQueryInternal, GetDocumentReferenceTypeQueryResponseInternal>
{
    public async Task<GetDocumentReferenceTypeQueryResponseInternal> Handle(
        GetDocumentReferenceTypeQueryInternal request,
        CancellationToken cancellationToken)
    {
        DomainId? domainId = string.IsNullOrWhiteSpace(request.DomainId) ? null : DomainId.Parse(request.DomainId);

        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        ReferenceType reference = await documentReferenceTypeRepository.GetRequired(domainId, referenceType, cancellationToken);

        var result = GetDocumentReferenceTypeQueryResponseInternalConverter.FromDomain(reference);

        return result;
    }
}
