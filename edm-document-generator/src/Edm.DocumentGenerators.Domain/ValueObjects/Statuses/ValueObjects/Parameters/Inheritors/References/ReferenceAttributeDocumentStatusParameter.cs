using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;

public sealed record ReferenceAttributeDocumentStatusParameter(
    DocumentStatusParameterKind Kind,
    Metadata<ReferenceAttributeDocumentStatusParameter> ReferenceType,
    Id<DocumentAttribute>[] Values,
    bool IsArray) : DocumentStatusParameter(Kind)
{
    public override string ToString()
    {
        string values = string.Join(", ", Values.Select(v => v.ToString()));

        return $"{{ {BaseToString()}, ReferenceType: {ReferenceType}, Values: {values} }}";
    }
}
