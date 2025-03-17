using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.Changes;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged;

internal static class DocumentStatusChangedAuditRecordDbConverter
{
    internal static DocumentStatusChangedAuditRecordDb FromDomain(DocumentStatusChangedAuditRecord record)
    {
        DocumentStatusChangedAuditRecordChangeDb change = DocumentStatusChangedAuditRecordChangeDbConverter.FromDomain(record.Change);

        DocumentStatusTransitionParameterValueDb[] statusTransitionParametersValues = record.StatusTransitionParametersValues
            .Select(DocumentStatusTransitionParameterValueDbFromDomainConverter.FromDomain)
            .ToArray();

        var result = new DocumentStatusChangedAuditRecordDb
        {
            Change = change,
            StatusTransitionParametersValues = { statusTransitionParametersValues }
        };

        return result;
    }

    internal static DocumentStatusChangedAuditRecord ToDomain(
        AuditRecordHeading<Document> heading,
        DocumentStatusChangedAuditRecordDb record,
        DocumentStatusTransition[] statusTransitions)
    {
        AuditRecordChange<Id<DocumentStatus>> change =
            DocumentStatusChangedAuditRecordChangeDbConverter.ToDomain(record.Change);

        DocumentStatusTransitionParameter[] parameters =
            statusTransitions.SingleOrDefault(t => t.From.Id == change.From && t.To.Id == change.To)?.Parameters ?? [];

        DocumentStatusTransitionParameterValue[] statusTransitionParameterValue = record.StatusTransitionParametersValues
            .Select(v => DocumentStatusTransitionParameterValueDbToDomainConverter.ToDomain(v, parameters))
            .ToArray();

        DocumentStatusChangedAuditRecord result =
            DocumentStatusChangedAuditRecordFactory.CreateFromDb(heading, change, statusTransitionParameterValue);

        return result;
    }
}
