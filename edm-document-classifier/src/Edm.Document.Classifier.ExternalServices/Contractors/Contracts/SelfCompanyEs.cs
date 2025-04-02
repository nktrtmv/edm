using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

public sealed class SelfCompanyEs : ITypedReference
{
    public SelfCompanyEs(long id, string name, string? inn, string? kpp, long personId)
    {
        Id = id;
        Name = name;
        Inn = inn;
        Kpp = kpp;
        PersonId = personId;
    }

    public long Id { get; }
    public string Name { get; }
    public string? Inn { get; }
    public string? Kpp { get; }
    public long PersonId { get; }
}
