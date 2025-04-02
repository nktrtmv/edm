using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings.Factories;

public static class StringDocumentStatusParameterFactory
{
    public static StringDocumentStatusParameter CreateFrom(DocumentStatusParameterKind kind)
    {
        var result = new StringDocumentStatusParameter(kind, string.Empty);

        return result;
    }
}
