using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.Slim;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Briefs;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll.Contracts.Slim;

internal static class DocumentTemplateSlimDtoConverter
{
    internal static DocumentTemplateSlimDto FromInternal(DocumentTemplateSlimInternal template)
    {
        DocumentTemplateStatusDto status = DocumentTemplateStatusDboConverter.FromInternal(template.Status);

        AuditBriefDto audit = AuditBriefDtoConverter.FromInternal(template.Audit);

        var result = new DocumentTemplateSlimDto
        {
            Id = template.Id,
            Name = template.Name,
            Status = status,
            Audit = audit
        };

        return result;
    }
}
