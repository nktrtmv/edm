using System.Diagnostics.CodeAnalysis;

using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.ExternalServices;

namespace Edm.DocumentGenerator.Gateway.Core.Validators;

public delegate bool DocumentCondition(string domainId, IRoleAdapter roleAdapter, ValidateDocumentQueryResponse validateResponse);

[SuppressMessage("ReSharper", "ArrangeMethodOrOperatorBody")]
public static class DocumentUpdateConditions
{
    private const string ElectronicSigningTypeValue = "ElectronicDocumentManagement"; // ЭДО

    public static DocumentCondition HasEdoAndContractor { get; } = (domainId, adapter, validateResponse) =>
        domainId == Constants.Contracts &&
        DocumentAttributeValuesDetailedFetcher.FetchSingleAttributeValueOrNullByDocumentRole(
                validateResponse.UpdatedAttributesValues,
                DocumentAttributeValueDetailedDto.ValueOneofCase.AsReference,
                10)
            ?.AsReference.Values.Count > 0
        && DocumentAttributeValuesDetailedFetcher.FetchSingleAttributeValueOrNullByDocumentRole(
                validateResponse.UpdatedAttributesValues,
                DocumentAttributeValueDetailedDto.ValueOneofCase.AsReference,
                8)
            ?.AsReference.Values.Contains(ElectronicSigningTypeValue) == true;
}
