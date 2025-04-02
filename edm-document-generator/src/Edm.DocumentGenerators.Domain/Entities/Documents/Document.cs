using System.Text.Json.Serialization;

using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StagesTypes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StagesTypes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Domain.Entities.Documents;

public sealed class Document
{
    internal Document(
        DomainId domainId,
        Id<Document> id,
        Id<DocumentTemplate> templateId,
        SystemName? templateSystemName,
        DocumentStatus status,
        DocumentStatusStateMachine statusStateMachine,
        DocumentAttributeValue[] attributesValues,
        DocumentErrors documentErrors,
        DocumentValidator[] validators,
        DocumentNotification[] notifications,
        DocumentApprovalData approvalData,
        DocumentSigningData signingData,
        Metadata<Front> frontMetadata,
        Audit<Document> audit,
        DocumentParameters parameters,
        List<DocumentApplicationEvent> applicationEvents,
        ConcurrencyToken<Document> concurrencyToken,
        UtcDateTime<DocumentTemplate>? templateUpdatedDate)
    {
        Id = id;
        DomainId = domainId;
        TemplateId = templateId;
        Status = status;
        StatusStateMachine = statusStateMachine;
        AttributesValues = attributesValues;
        DocumentErrors = documentErrors;
        Validators = validators;
        Notifications = notifications;
        ApprovalData = approvalData;
        SigningData = signingData;
        FrontMetadata = frontMetadata;
        Audit = audit;
        Parameters = parameters;
        ApplicationEvents = applicationEvents;
        ConcurrencyToken = concurrencyToken;
        TemplateUpdatedDate = templateUpdatedDate;
        TemplateSystemName = templateSystemName;
    }

    public DomainId DomainId { get; }

    public Id<Document> Id { get; }

    public Id<DocumentTemplate> TemplateId { get; }

    public SystemName? TemplateSystemName { get; }

    public DocumentStatus Status { get; private set; }

    [JsonIgnore]
    public DocumentStatusStateMachine StatusStateMachine { get; private set; }

    public DocumentAttributeValue[] AttributesValues { get; private set; }
    public DocumentErrors DocumentErrors { get; private set; }
    public DocumentValidator[] Validators { get; private set; }
    public DocumentNotification[] Notifications { get; }
    public DocumentApprovalData ApprovalData { get; }
    public DocumentSigningData SigningData { get; }
    public Metadata<Front> FrontMetadata { get; }
    public Audit<Document> Audit { get; private set; }
    public DocumentParameters Parameters { get; }
    public List<DocumentApplicationEvent> ApplicationEvents { get; }
    public ConcurrencyToken<Document> ConcurrencyToken { get; private set; }
    public UtcDateTime<DocumentTemplate>? TemplateUpdatedDate { get; }

    public DocumentStageType StageType => DocumentStageTypeDetector.Detect(StatusStateMachine, Status);

    public void SetStatus(DocumentStatus status)
    {
        Status = status;
    }

    public void SetAttributesValues(DocumentAttributeValue[] attributesValues)
    {
        AttributesValues = attributesValues;
    }

    public void SetErrors(DocumentErrors errors)
    {
        DocumentErrors = errors;
    }

    internal void SetAudit(Audit<Document> audit)
    {
        Audit = audit;
    }

    public void SetConcurrencyToken(ConcurrencyToken<Document> concurrencyToken)
    {
        ConcurrencyToken = concurrencyToken;
    }

    public override string ToString()
    {
        var approvalAttributesVersion = UtcDateTimeConverterTo.ToString(ApprovalData.AttributesVersion);

        return $"{{ Id: {Id}, TemplateId: {TemplateId}, ApprovalAttributesVersion: {approvalAttributesVersion} }}";
    }
}
