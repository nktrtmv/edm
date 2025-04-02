using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.DocumentAutorChangedDetector;

internal static class DocumentAuthorChangedDetector
{
    internal static Id<User>? GetChangedOrNull(EventChange<DocumentAttributeValue> change, DocumentEventContext context)
    {
        Id<User>? authorIdFrom = TryGetAuthorId(change.From);

        Id<User>? authorIdTo = TryGetAuthorId(change.To);

        Id<User>? result = authorIdFrom == authorIdTo
            ? null
            : authorIdTo;

        return result;
    }

    private static Id<User>? TryGetAuthorId(DocumentAttributeValue attributeValue)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentAuthor,
            DocumentAttributeReferenceTypes.Employees);

        string[]? values = selector.GetSingleValueOrNull(attributeValue);

        string? authorId = values?.SingleOrDefault();

        if (authorId is null)
        {
            return null;
        }

        Id<User> result = IdConverterFrom<User>.FromString(authorId);

        return result;
    }
}
