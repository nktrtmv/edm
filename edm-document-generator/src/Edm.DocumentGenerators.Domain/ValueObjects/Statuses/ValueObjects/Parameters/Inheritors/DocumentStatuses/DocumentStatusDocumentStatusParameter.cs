using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;

public sealed record DocumentStatusDocumentStatusParameter(DocumentStatusParameterKind Kind, Id<DocumentStatus>? Value) : DocumentStatusParameter(Kind)
{
    public override string ToString()
    {
        return $"{{ {BaseToString()}, Value: {Value} }}";
    }
}
