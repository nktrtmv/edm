using System.Text.Json;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ExternalReferences;

public sealed record ExternalReference(string[] PossibleExternalIds) : ITypedReference
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(PossibleExternalIds);
    }
};
