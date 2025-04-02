using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Bulk.Values;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Bulk;

internal static class BulkUpsertReferenceValuesCommandConverter
{
    public static BulkUpsertReferenceValuesCommandInternal ToInternal(BulkUpsertReferenceValuesCommand command)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(command.ReferenceType);

        BulkUpsertReferenceValueInternal[] values = command.Values.Select(BulkUpsertReferenceValueConverter.ToInternal).ToArray();

        BulkUpsertReferenceValuesCommandInternal result = new BulkUpsertReferenceValuesCommandInternal(
            command.DomainId,
            referenceType,
            values,
            command.CurrentUserId);

        return result;
    }
}
