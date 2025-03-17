using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.ClerkChangedDetector;

internal static class DocumentClerkChangedDetector
{
    internal static Id<User>? GetChangedOrNull(EventChange<DocumentAttributeValue> change)
    {
        Id<User>? clerkIdFrom = TryGetClerkId(change.From);

        Id<User>? clerkIdTo = TryGetClerkId(change.To);

        Id<User>? result = clerkIdFrom == clerkIdTo
            ? null
            : clerkIdTo;

        return result;
    }

    private static Id<User>? TryGetClerkId(DocumentAttributeValue attributeValue)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentClerk,
            DocumentAttributeReferenceTypes.Employees);

        string[]? values = selector.GetSingleValueOrNull(attributeValue);

        string? clerkId = values?.SingleOrDefault();

        if (clerkId is null)
        {
            return null;
        }

        Id<User> result = IdConverterFrom<User>.FromString(clerkId);

        return result;
    }
}
