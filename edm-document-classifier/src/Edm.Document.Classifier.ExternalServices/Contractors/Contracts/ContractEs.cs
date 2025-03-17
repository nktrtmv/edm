using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

public sealed class ContractEs : ITypedReference
{
    public ContractEs(long id, string name, string state, string type, string contractorName)
    {
        Id = id;
        Name = name;
        State = state;
        Type = type;
        ContractorName = contractorName;
    }

    public long Id { get; init; }
    public string Name { get; init; } = null!;
    public string State { get; init; } = null!;
    public string Type { get; init; } = null!;
    public string ContractorName { get; init; } = null!;
}
