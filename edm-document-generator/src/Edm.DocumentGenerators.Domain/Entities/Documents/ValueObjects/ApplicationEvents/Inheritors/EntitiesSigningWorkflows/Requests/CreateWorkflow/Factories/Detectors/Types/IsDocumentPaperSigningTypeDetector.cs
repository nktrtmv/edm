using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Types;

internal static class IsDocumentPaperSigningTypeDetector
{
    private const string ElectronicSigningTypeValue = "ElectronicDocumentManagement";
    private const string ContractorElectronicSigningTypeValue = "ContractorElectronicDocumentManagement";
    private const string PaperSigningTypeValue = "PaperDocumentManagement";

    internal static bool Detect(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.SigningType,
            DocumentAttributeReferenceTypes.ContractSigningTypes,
            "Вид подписания");

        string value = fetcher.FetchSingleAttributeWithSingleValue(selector);

        bool result = value switch
        {
            ElectronicSigningTypeValue => false,
            ContractorElectronicSigningTypeValue => true,
            PaperSigningTypeValue => true,
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }
}
