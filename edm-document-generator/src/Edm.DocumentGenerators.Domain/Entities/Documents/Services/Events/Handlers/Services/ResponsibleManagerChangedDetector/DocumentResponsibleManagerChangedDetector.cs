using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.ResponsibleManagerChangedDetector;

internal static class DocumentResponsibleManagerChangedDetector
{
    internal static Id<User>? GetChangedOrNull(EventChange<DocumentAttributeValue> change)
    {
        Id<User>? responsibleManagerIdFrom = TryGetResponsibleManagerId(change.From);

        Id<User>? responsibleManagerIdTo = TryGetResponsibleManagerId(change.To);

        Id<User>? result = responsibleManagerIdFrom == responsibleManagerIdTo
            ? null
            : responsibleManagerIdTo;

        return result;
    }

    private static Id<User>? TryGetResponsibleManagerId(DocumentAttributeValue attributeValue)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentResponsible,
            DocumentAttributeReferenceTypes.Employees);

        string[]? values = selector.GetSingleValueOrNull(attributeValue);

        string? responsibleManagerId = values?.SingleOrDefault();

        Id<User>? result = NullableConverter.Convert(responsibleManagerId, IdConverterFrom<User>.FromString);

        return result;
    }
}
