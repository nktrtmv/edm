namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;

public sealed class ContractorInternal(string id, string displayValue, string displaySubValue)
{
    public string Id { get; set; } = id;
    public string DisplayValue { get; set; } = displayValue;
    public string DisplaySubValue { get; set; } = displaySubValue;

    public static ContractorInternal? CreateNotEnriched(string id)
    {
        return new ContractorInternal(id, string.Empty, string.Empty);
    }
}
