using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;

internal static class DocumentStatusPrototypeInternalConverter
{
    internal static DocumentStatusPrototypeInternal FromDomain(DocumentStatus status, DocumentTemplate template)
    {
        var id = IdConverterTo.ToString(status.Id);

        DocumentStatusTypeInternal type = DocumentStatusTypeInternalConverter.FromDomain(status.Type);

        DocumentStatusParameterInternal[] parameters = status.Parameters.Select(DocumentStatusParameterInternalConverter.FromDomain).ToArray();

        var result = new DocumentStatusPrototypeInternal(id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }

    internal static DocumentStatus ToDomain(DocumentStatusPrototypeInternal status)
    {
        Id<DocumentStatus>? id = IdConverterFrom<DocumentStatus>.FromString(status.Id);

        DocumentStatusType type = DocumentStatusTypeInternalConverter.ToDomain(status.Type);

        DocumentStatusParameter[] parameters = status.Parameters.Select(DocumentStatusParameterInternalConverter.ToDomain).ToArray();

        DocumentStatus? result = DocumentStatusFactory.CreateFrom(id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
