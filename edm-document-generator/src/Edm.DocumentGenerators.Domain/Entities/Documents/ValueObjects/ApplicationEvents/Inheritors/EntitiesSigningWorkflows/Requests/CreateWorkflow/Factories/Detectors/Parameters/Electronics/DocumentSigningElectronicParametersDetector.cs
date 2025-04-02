using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Attachments;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Dates;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parameters.Electronics;

internal static class DocumentSigningElectronicParametersDetector
{
    internal static DocumentSigningElectronicParameters Detect(DocumentAttributesValuesFetcher fetcher)
    {
        string documentName = GetDocumentName(fetcher);

        string documentNumber = GetDocumentRegistrationNumber(fetcher);

        UtcDateTime<DocumentSigningElectronicParameters> documentDate = GetDocumentDate(fetcher);

        Id<Attachment>[] documentsAttachmentsIds = GetDocumentsAttachmentsIds(fetcher);

        DocumentSigningElectronicParameters result = DocumentSigningElectronicParametersFactory.CreateFrom(
            documentName,
            documentNumber,
            documentDate,
            documentsAttachmentsIds);

        return result;
    }

    private static string GetDocumentName(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentStringAttributeValueSelector(DocumentAttributeDocumentRole.DocumentName);

        string result = fetcher.FetchSingleAttributeWithSingleValue(selector);

        return result;
    }

    private static string GetDocumentRegistrationNumber(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentStringAttributeValueSelector(DocumentAttributeDocumentRole.DocumentRegistrationNumber);

        string result = fetcher.FetchSingleAttributeWithSingleValue(selector);

        return result;
    }

    private static UtcDateTime<DocumentSigningElectronicParameters> GetDocumentDate(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentDateAttributeValueSelector(DocumentAttributeDocumentRole.DocumentDate);

        UtcDateTime<DateDocumentAttributeValue> documentDate = fetcher.FetchSingleAttributeWithSingleValue(selector);

        UtcDateTime<DocumentSigningElectronicParameters> result = UtcDateTimeConverterFrom<DocumentSigningElectronicParameters>.From(documentDate);

        return result;
    }

    private static Id<Attachment>[] GetDocumentsAttachmentsIds(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentAttachmentAttributeValueSelector(
            DocumentAttributeDocumentRole.SigningDocumentsToSign,
            "Соглашение",
            "Приложения к Соглашению");

        string[] attachmentsIds = fetcher.FetchManyAttributesWithManyValues(selector);

        Id<Attachment>[] result = attachmentsIds.Select(IdConverterFrom<Attachment>.FromString).ToArray();

        return result;
    }
}
