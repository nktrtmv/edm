using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;

public sealed record StringDocumentStatusParameter(DocumentStatusParameterKind Kind, string Value) : DocumentStatusParameter(Kind)
{
    public override string ToString()
    {
        return $"{{ {BaseToString()}, Value: {Value} }}";
    }
}
