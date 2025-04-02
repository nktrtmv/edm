using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.Slim;

internal static class DocumentTemplateSlimInternalConverter
{
    internal static DocumentTemplateSlimInternal FromDomain(DocumentTemplate template)
    {
        var id = IdConverterTo.ToString(template.Id);

        AuditBriefInternal<DocumentTemplateDetailedInternal> audit =
            AuditBriefInternalFromDomainConverter<DocumentTemplateDetailedInternal>.FromDomain(template.Audit.Brief);

        var result = new DocumentTemplateSlimInternal(
            id,
            template.Name.Value,
            template.Status,
            audit);

        return result;
    }
}
