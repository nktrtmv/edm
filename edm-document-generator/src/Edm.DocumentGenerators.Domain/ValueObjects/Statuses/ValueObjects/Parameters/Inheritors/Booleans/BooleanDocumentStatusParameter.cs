using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;

public sealed record BooleanDocumentStatusParameter(DocumentStatusParameterKind Kind, bool Value) : DocumentStatusParameter(Kind)
{
    public override string ToString()
    {
        return $"{{ {BaseToString()}, Value: {Value} }}";
    }
}
