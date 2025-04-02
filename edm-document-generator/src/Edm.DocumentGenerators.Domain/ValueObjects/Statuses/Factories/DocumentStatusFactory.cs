using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.Factories;

public static class DocumentStatusFactory
{
    public static DocumentStatus CreateFrom(Id<DocumentStatus> id, DocumentStatusType type, DocumentStatusParameter[] parameters, string systemName, string displayName)
    {
        DocumentStatus result = CreateFromDb(id, type, parameters, systemName, displayName);

        return result;
    }

    public static DocumentStatus CreateNew(DocumentStatusType type, string systemName, string displayName)
    {
        var id = Id<DocumentStatus>.CreateNew();

        DocumentStatusParameter[] parameters = Array.Empty<DocumentStatusParameter>();

        DocumentStatus result = CreateFromDb(id, type, parameters, systemName, displayName);

        return result;
    }

    public static DocumentStatus CreateFromDb(Id<DocumentStatus> id, DocumentStatusType type, DocumentStatusParameter[] parameters, string systemName, string displayName)
    {
        var result = new DocumentStatus(id, type, parameters, systemName, displayName);

        return result;
    }
}
