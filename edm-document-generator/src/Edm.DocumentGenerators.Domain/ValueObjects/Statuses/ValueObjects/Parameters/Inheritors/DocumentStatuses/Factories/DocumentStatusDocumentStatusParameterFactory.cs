using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses.Factories;

public static class DocumentStatusDocumentStatusParameterFactory
{
    public static DocumentStatusDocumentStatusParameter CreateFrom(DocumentStatusParameterKind kind, Id<DocumentStatus>? value = null)
    {
        DocumentStatusDocumentStatusParameter result = CreateFromDb(kind, value);

        return result;
    }

    public static DocumentStatusDocumentStatusParameter CreateFromDb(DocumentStatusParameterKind kind, Id<DocumentStatus>? value)
    {
        var result = new DocumentStatusDocumentStatusParameter(kind, value);

        return result;
    }
}
