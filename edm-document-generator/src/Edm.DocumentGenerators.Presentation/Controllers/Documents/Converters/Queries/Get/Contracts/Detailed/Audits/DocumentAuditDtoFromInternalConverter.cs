using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Briefs;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits;

public static class DocumentAuditDtoFromInternalConverter
{
    public static DocumentAuditDto FromInternal(AuditInternal<DocumentDetailedInternal> audit)
    {
        AuditBriefDto brief = AuditBriefDtoConverter.FromInternal(audit.Brief);

        DocumentAuditRecordDto[] records = audit.Records.Select(DocumentAuditRecordDtoConverter.FromDomain).ToArray();

        var result = new DocumentAuditDto
        {
            Brief = brief,
            Records = { records }
        };

        return result;
    }
}
