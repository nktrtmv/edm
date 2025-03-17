using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Strings;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories.Detectors
    .Parameters;

internal static class DocumentApprovalParametersDetector
{
    internal static DocumentApprovalParameters Detect(Document document)
    {
        var fetcher = new DocumentAttributesValuesFetcher(document.AttributesValues);

        string title = GetTitle(fetcher);

        var description = $"Approval workflow for Document {document.Id}, Template: {document.TemplateId}";

        Id<User> clerkId = GetClerkId(fetcher);

        Id<User> documentAuthorId = GetDocumentAuthorId(fetcher, document);

        var result = new DocumentApprovalParameters(title, description, clerkId, documentAuthorId);

        return result;
    }

    private static string GetTitle(DocumentAttributesValuesFetcher fetcher)
    {
        string? result = GetDocumentNumber(fetcher);

        if (string.IsNullOrWhiteSpace(result))
        {
            result = GetDocumentRegistrationNumber(fetcher);
        }

        return result;
    }

    private static string? GetDocumentNumber(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentStringAttributeValueSelector(DocumentAttributeDocumentRole.DocumentNumber);

        string? result = fetcher.FetchSingleAttributeOrNullWithSingleValueOrNull(selector);

        return result;
    }

    private static string GetDocumentRegistrationNumber(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentStringAttributeValueSelector(DocumentAttributeDocumentRole.DocumentRegistrationNumber);

        string result = fetcher.FetchSingleAttributeWithSingleValue(selector);

        return result;
    }

    private static Id<User> GetClerkId(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentClerk,
            DocumentAttributeReferenceTypes.Employees);

        string clerkId = fetcher.FetchSingleAttributeWithSingleValue(selector);

        Id<User> result = IdConverterFrom<User>.FromString(clerkId);

        return result;
    }

    private static Id<User> GetDocumentAuthorId(DocumentAttributesValuesFetcher fetcher, Document document)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentAuthor,
            DocumentAttributeReferenceTypes.Employees);

        string authorId = fetcher.FetchSingleAttributeOrNullWithSingleValueOrNull(selector) ??
            IdConverterTo.ToString(document.Audit.Brief.CreatedById);

        Id<User> result = IdConverterFrom<User>.FromString(authorId);

        return result;
    }
}
