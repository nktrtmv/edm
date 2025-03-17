using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Categories.Contracts;

public sealed class CategoryEs : ITypedReference
{
    public CategoryEs(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public long Id { get; }
    public string Name { get; }
}
