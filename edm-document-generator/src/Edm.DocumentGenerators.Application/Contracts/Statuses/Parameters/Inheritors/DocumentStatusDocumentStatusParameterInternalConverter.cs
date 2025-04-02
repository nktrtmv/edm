using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

internal static class DocumentStatusDocumentStatusParameterInternalConverter
{
    internal static DocumentStatusDocumentStatusParameterInternal FromDomain(
        DocumentStatusParameterKind kind,
        DocumentStatusDocumentStatusParameter p)
    {
        Id<DocumentStatusInternal>? value = NullableConverter.Convert(p.Value, IdConverterFrom<DocumentStatusInternal>.From);

        var result = new DocumentStatusDocumentStatusParameterInternal(kind, value);

        return result;
    }

    internal static DocumentStatusDocumentStatusParameter ToDomain(DocumentStatusParameterKind kind, DocumentStatusDocumentStatusParameterInternal p)
    {
        Id<DocumentStatus>? value = NullableConverter.Convert(p.Value, IdConverterFrom<DocumentStatus>.From);

        DocumentStatusDocumentStatusParameter result = DocumentStatusDocumentStatusParameterFactory.CreateFrom(kind, value);

        return result;
    }
}
