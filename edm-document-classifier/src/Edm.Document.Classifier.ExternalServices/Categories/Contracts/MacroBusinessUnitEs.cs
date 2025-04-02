using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Categories.Contracts;

public sealed class MacroBusinessUnitEs : ITypedReference
{
    public MacroBusinessUnitEs(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }
    public string Name { get; private set; }
}
