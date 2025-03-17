using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

public interface IDocumentReferenceValueRepository
{
    Task Insert(ReferenceValue referenceValue, CancellationToken cancellationToken);

    Task Update(ReferenceValue referenceValue, Id<ReferenceValue>? newId, CancellationToken cancellationToken);

    Task BulkUpsert(ReferenceValue[] referenceValues, CancellationToken cancellationToken);

    Task<ReferenceValue> GetRequired(Id<ReferenceType> referenceTypeId, Id<ReferenceValue> referenceValueId, CancellationToken cancellationToken);

    Task<ReferenceValue?> Get(Id<ReferenceType> referenceTypeId, Id<ReferenceValue> referenceValueId, CancellationToken cancellationToken);
    Task<ReferenceValue[]> GetByIds(Id<ReferenceType> referenceTypeId, Id<ReferenceValue>[] referenceValueIds, CancellationToken cancellationToken);

    Task<ReferenceValue[]> GetAll(
        Id<ReferenceType> referenceTypeId,
        GetAllDocumentReferenceTypesQueryParams queryParams,
        bool showHidden,
        CancellationToken cancellationToken);
}
