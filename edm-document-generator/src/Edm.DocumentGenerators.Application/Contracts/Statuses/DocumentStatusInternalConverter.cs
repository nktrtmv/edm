using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses;

internal static class DocumentStatusInternalConverter
{
    internal static DocumentStatusInternal FromDomain(DocumentStatus status)
    {
        var id = IdConverterTo.ToString(status.Id);

        DocumentStatusTypeInternal type = DocumentStatusTypeInternalConverter.FromDomain(status.Type);

        DocumentStatusParameterInternal[] parameters = status.Parameters.Select(DocumentStatusParameterInternalConverter.FromDomain).ToArray();

        var result = new DocumentStatusInternal(id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }

    internal static DocumentStatus ToDomain(DocumentStatusInternal status)
    {
        Id<DocumentStatus> id = IdConverterFrom<DocumentStatus>.FromString(status.Id);

        DocumentStatusType type = DocumentStatusTypeInternalConverter.ToDomain(status.Type);

        DocumentStatusParameter[] parameters = status.Parameters.Select(DocumentStatusParameterInternalConverter.ToDomain).ToArray();

        DocumentStatus result = DocumentStatusFactory.CreateFrom(id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
