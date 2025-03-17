using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;

public static class DocumentReferenceValueFactory
{
    public static ReferenceValue CreateNew(
        Id<ReferenceType> referenceTypeId,
        string displayValue,
        string displaySubValue,
        bool isHidden,
        Id<User> createdById,
        Id<ReferenceValue>? id = null)
    {
        id ??= Id<ReferenceValue>.CreateNew();

        var concurrencyToken = ConcurrencyToken<ReferenceValue>.Now;

        UtcDateTime<DateTime> currentDateTime = UtcDateTime<DateTime>.Now;

        var result = new ReferenceValue(
            referenceTypeId,
            id.Value,
            displayValue,
            displaySubValue,
            isHidden,
            createdById,
            createdById,
            currentDateTime,
            currentDateTime,
            concurrencyToken);

        return result;
    }
}
