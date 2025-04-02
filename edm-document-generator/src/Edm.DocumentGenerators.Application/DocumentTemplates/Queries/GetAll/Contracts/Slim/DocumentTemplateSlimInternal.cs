using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.Slim;

public sealed class DocumentTemplateSlimInternal
{
    internal DocumentTemplateSlimInternal(
        string id,
        string name,
        DocumentTemplateStatus status,
        AuditBriefInternal<DocumentTemplateDetailedInternal> audit)
    {
        Id = id;
        Name = name;
        Status = status;
        Audit = audit;
    }

    public string Id { get; }
    public string Name { get; }
    public DocumentTemplateStatus Status { get; }
    public AuditBriefInternal<DocumentTemplateDetailedInternal> Audit { get; }
}
