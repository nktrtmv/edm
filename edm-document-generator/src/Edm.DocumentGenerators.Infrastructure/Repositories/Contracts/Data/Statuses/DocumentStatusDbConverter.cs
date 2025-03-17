using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Types;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses;

internal static class DocumentStatusDbConverter
{
    internal static DocumentStatusDb FromDomain(DocumentStatus status)
    {
        var id = IdConverterTo.ToString(status.Id);

        DocumentStatusTypeDb type = DocumentStatusTypeDbConverter.FromDomain(status.Type);

        DocumentStatusParameterDb[] parameters = status.Parameters.Select(DocumentStatusParameterDbFromDomainConverter.FromDomain).ToArray();

        var result = new DocumentStatusDb
        {
            Id = id,
            Type = type,
            Parameters = { parameters },
            SystemName = status.SystemName,
            DisplayName = status.DisplayName
        };

        return result;
    }

    internal static DocumentStatus ToDomain(DocumentStatusDb status)
    {
        Id<DocumentStatus> id = IdConverterFrom<DocumentStatus>.FromString(status.Id);

        DocumentStatusType type = DocumentStatusTypeDbConverter.ToDomain(status.Type);

        DocumentStatusParameter[] parameters = status.Parameters.Select(DocumentStatusParameterDbToDomainConverter.ToDomain).ToArray();

        DocumentStatus result = DocumentStatusFactory.CreateFromDb(id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
