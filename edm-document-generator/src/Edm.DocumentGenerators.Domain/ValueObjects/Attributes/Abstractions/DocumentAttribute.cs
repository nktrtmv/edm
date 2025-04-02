using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

public abstract record DocumentAttribute(DocumentAttributeData Data)
{
    public Id<DocumentAttribute> Id => Data.Id;
    public bool IsArray => Data.IsArray;
    public SystemName? SystemName => Data.SystemName;
    public string DisplayName => Data.DisplayName;
}
