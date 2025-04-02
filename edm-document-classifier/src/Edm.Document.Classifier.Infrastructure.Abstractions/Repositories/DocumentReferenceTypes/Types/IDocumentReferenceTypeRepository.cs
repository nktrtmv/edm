using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

public interface IDocumentReferenceTypeRepository
{
    Task<int> Upsert(ReferenceType documentReferenceType, CancellationToken cancellationToken);
    Task<ReferenceType?> Get(DomainId? domainId, Id<ReferenceType> referenceTypeId, CancellationToken cancellationToken);
    Task<ReferenceType> GetRequired(DomainId? domainId, Id<ReferenceType> referenceTypeId, CancellationToken cancellationToken);

    Task<ReferenceType[]> GetAll(DomainId? domainId, GetAllDocumentReferenceTypesQueryParams queryParams, CancellationToken cancellationToken);
    Task<int?> GetLastReferenceTypeId(CancellationToken cancellationToken);
}
