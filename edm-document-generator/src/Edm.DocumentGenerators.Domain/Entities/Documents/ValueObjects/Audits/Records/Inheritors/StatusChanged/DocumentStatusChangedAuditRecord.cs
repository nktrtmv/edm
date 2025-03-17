using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged;

public sealed record DocumentStatusChangedAuditRecord(
    AuditRecordHeading<Document> Heading,
    AuditRecordChange<Id<DocumentStatus>> Change,
    DocumentStatusTransitionParameterValue[] StatusTransitionParametersValues)
    : AuditChangeRecord<Document, AuditRecordChange<Id<DocumentStatus>>>(Heading, Change);
