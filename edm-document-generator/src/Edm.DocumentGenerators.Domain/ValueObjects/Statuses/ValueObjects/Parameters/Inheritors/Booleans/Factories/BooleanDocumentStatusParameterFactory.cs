using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans.Factories;

public static class BooleanDocumentStatusParameterFactory
{
    public static BooleanDocumentStatusParameter CreateFrom(DocumentStatusParameterKind kind, bool value = true)
    {
        var result = new BooleanDocumentStatusParameter(kind, value);

        return result;
    }
}
