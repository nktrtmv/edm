using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.StagesTypes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts;

public sealed class DocumentExternal
{
    public DocumentExternal(
        Id<DocumentExternal> id,
        Id<DocumentTemplateExternal> templateId,
        string domainId,
        DocumentAttributeValueExternal[] attributesValues,
        DocumentStatusExternal status,
        DocumentStageTypeExternal stageType,
        DocumentApprovalDataExternal approvalData,
        DocumentSigningDataExternal signingData,
        DocumentAuditExternal audit,
        UtcDateTime<DocumentTemplateExternal>? templateUpdatedDate)
    {
        Id = id;
        TemplateId = templateId;
        DomainId = domainId;
        AttributesValues = attributesValues;
        Status = status;
        StageType = stageType;
        ApprovalData = approvalData;
        SigningData = signingData;
        Audit = audit;
        TemplateUpdatedDate = templateUpdatedDate;
    }

    public Id<DocumentExternal> Id { get; }
    public Id<DocumentTemplateExternal> TemplateId { get; }
    public string DomainId { get; }
    public DocumentAttributeValueExternal[] AttributesValues { get; }
    public DocumentStatusExternal Status { get; }
    public DocumentStageTypeExternal StageType { get; }
    public DocumentApprovalDataExternal ApprovalData { get; }
    public DocumentSigningDataExternal SigningData { get; }
    public DocumentAuditExternal Audit { get; }
    public UtcDateTime<DocumentTemplateExternal>? TemplateUpdatedDate { get; }
}
