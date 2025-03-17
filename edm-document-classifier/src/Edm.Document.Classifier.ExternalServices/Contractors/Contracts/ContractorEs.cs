using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

public sealed class ContractorEs : ITypedReference
{
    public ContractorEs(long id, string inn, string name, string? kpp, long personId)
    {
        Id = id;
        Inn = inn;
        Name = name;
        Kpp = kpp;
        PersonId = personId;
    }

    public long Id { get; }
    public string Inn { get; }
    public string Name { get; }
    public string? Kpp { get; }
    public long PersonId { get; }
}
