using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;

public sealed class DocumentTemplate
{
    internal DocumentTemplate(
        DomainId domainId,
        Id<DocumentTemplate> id,
        DocumentTemplateName name,
        SystemName? systemName,
        DocumentTemplateStatus status,
        DocumentTemplateApprovalData approvalData,
        DocumentPrototype documentPrototype,
        Metadata<Front> frontMetadata,
        Audit<DocumentTemplate> audit,
        ConcurrencyToken<DocumentTemplate> concurrencyToken,
        bool isDeleted)
    {
        DomainId = domainId;
        Id = id;
        Name = name;
        Status = status;
        ApprovalData = approvalData;
        DocumentPrototype = documentPrototype;
        FrontMetadata = frontMetadata;
        Audit = audit;
        ConcurrencyToken = concurrencyToken;
        SystemName = systemName;
        IsDeleted = isDeleted;
    }

    public DomainId DomainId { get; }
    public Id<DocumentTemplate> Id { get; }
    public DocumentTemplateName Name { get; private set; }
    public DocumentTemplateStatus Status { get; private set; }
    public DocumentTemplateApprovalData ApprovalData { get; private set; }
    public DocumentPrototype DocumentPrototype { get; private set; }
    public Metadata<Front> FrontMetadata { get; private set; }
    public Audit<DocumentTemplate> Audit { get; private set; }
    public ConcurrencyToken<DocumentTemplate> ConcurrencyToken { get; }
    public SystemName? SystemName { get; private set; }
    public bool IsDeleted { get; private set; }

    internal void SetName(DocumentTemplateName name)
    {
        Name = name;
    }

    internal void SetStatus(DocumentTemplateStatus status)
    {
        Status = status;
    }

    internal void SetApprovalData(DocumentTemplateApprovalData approvalData)
    {
        ApprovalData = approvalData;
    }

    internal void SetDocumentPrototype(DocumentPrototype documentPrototype)
    {
        DocumentPrototype = documentPrototype;
    }

    internal void SetFrontMetadata(Metadata<Front> frontMetadata)
    {
        FrontMetadata = frontMetadata;
    }

    internal void SetAudit(Audit<DocumentTemplate> audit)
    {
        Audit = audit;
    }

    public void SetSystemName(SystemName? systemName)
    {
        SystemName = systemName;
    }

    public override string ToString()
    {
        string? approvalAttributesVersion = ApprovalData.AttributesVersion?.ToString() ?? string.Empty;

        return $"{{ Id: {Id}, ApprovalAttributesVersion: {approvalAttributesVersion}, Status: {Status} }}";
    }
}
