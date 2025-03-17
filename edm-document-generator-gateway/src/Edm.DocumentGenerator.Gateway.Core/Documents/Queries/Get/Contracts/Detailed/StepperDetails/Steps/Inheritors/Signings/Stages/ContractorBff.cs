namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

public sealed class ContractorBff(string id, string displayValue, string displaySubValue)
{
    public string Id { get; set; } = id;
    public string DisplayValue { get; set; } = displayValue;
    public string DisplaySubValue { get; set; } = displaySubValue;

    public static ContractorBff? CreateNotEnriched(string id)
    {
        return new ContractorBff(id, string.Empty, string.Empty);
    }
}
