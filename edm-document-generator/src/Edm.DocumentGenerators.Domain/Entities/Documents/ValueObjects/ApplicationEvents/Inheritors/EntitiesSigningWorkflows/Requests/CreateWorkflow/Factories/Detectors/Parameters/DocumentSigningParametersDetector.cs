using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parameters.Electronics;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parameters;

internal static class DocumentSigningParametersDetector
{
    internal static DocumentSigningParameters Detect(DocumentAttributesValuesFetcher fetcher, bool isPaperSigningType)
    {
        Id<User>? documentClerkId = GetDocumentClerkId(fetcher);

        DocumentSigningElectronicParameters? electronicParameters = isPaperSigningType
            ? null
            : DocumentSigningElectronicParametersDetector.Detect(fetcher);

        var result = new DocumentSigningParameters(documentClerkId, electronicParameters);

        return result;
    }

    private static Id<User>? GetDocumentClerkId(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentClerk,
            DocumentAttributeReferenceTypes.Employees);

        string? responsibleManagerId = fetcher.FetchSingleAttributeOrNullWithSingleValueOrNull(selector);

        Id<User>? result = NullableConverter.Convert(responsibleManagerId, IdConverterFrom<User>.FromString);

        return result;
    }
}
