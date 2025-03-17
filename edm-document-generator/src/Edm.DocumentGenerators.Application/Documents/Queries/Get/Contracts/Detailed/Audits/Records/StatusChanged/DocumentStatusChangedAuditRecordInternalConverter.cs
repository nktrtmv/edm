using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Services;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;

internal static class DocumentStatusChangedAuditRecordInternalConverter
{
    internal static DocumentStatusChangedAuditRecordInternal FromDomain(
        DocumentStatusChangedAuditRecord record,
        DocumentStatusInternalEnricher statusEnricher)
    {
        AuditRecordHeadingInternal<DocumentDetailedInternal> heading =
            AuditRecordHeadingInternalConverter<DocumentDetailedInternal>.FromDomain(record.Heading);

        AuditRecordChangeInternal<DocumentStatusInternal> change =
            AuditRecordChangeInternalConverter<DocumentStatusInternal>.FromDomain(record.Change, statusEnricher.FromDomain);

        DocumentStatusTransitionParameterValueInternal[] statusTransitionParametersValues =
            DocumentStatusTransitionParameterValueInternalFromDomainConverter.FromDomain(record.StatusTransitionParametersValues);

        var result = new DocumentStatusChangedAuditRecordInternal(heading, change, statusTransitionParametersValues);

        return result;
    }
}
