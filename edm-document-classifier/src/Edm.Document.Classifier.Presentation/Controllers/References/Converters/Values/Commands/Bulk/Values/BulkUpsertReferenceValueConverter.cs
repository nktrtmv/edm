using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts.Values;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Bulk.Values;

internal static class BulkUpsertReferenceValueConverter
{
    public static BulkUpsertReferenceValueInternal ToInternal(BulkUpsertReferenceValue value)
    {
        BulkUpsertReferenceValueInternal result = new BulkUpsertReferenceValueInternal(
            string.IsNullOrWhiteSpace(value.Id) ? null : value.Id,
            value.DisplayValue,
            string.IsNullOrWhiteSpace(value.DisplaySubValue) ? null : value.DisplaySubValue);

        return result;
    }
}
