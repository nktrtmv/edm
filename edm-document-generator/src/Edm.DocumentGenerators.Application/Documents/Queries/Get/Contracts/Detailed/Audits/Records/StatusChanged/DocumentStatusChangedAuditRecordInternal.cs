using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;

public sealed record DocumentStatusChangedAuditRecordInternal(
    AuditRecordHeadingInternal<DocumentDetailedInternal> Heading,
    AuditRecordChangeInternal<DocumentStatusInternal> Change,
    DocumentStatusTransitionParameterValueInternal[] StatusTransitionParametersValues)
    : AuditChangeRecordInternal<DocumentDetailedInternal, AuditRecordChangeInternal<DocumentStatusInternal>>(Heading, Change);
