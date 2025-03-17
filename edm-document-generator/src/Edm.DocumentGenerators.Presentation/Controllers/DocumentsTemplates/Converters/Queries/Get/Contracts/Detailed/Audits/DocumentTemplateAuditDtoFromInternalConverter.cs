using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Briefs;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get.Contracts.Detailed.Audits;

public static class DocumentTemplateAuditDtoFromInternalConverter
{
    public static DocumentTemplateAuditDto FromInternal<T>(AuditInternal<T> audit)
    {
        AuditBriefDto brief = AuditBriefDtoConverter.FromInternal(audit.Brief);

        var result = new DocumentTemplateAuditDto
        {
            Brief = brief
        };

        return result;
    }
}
