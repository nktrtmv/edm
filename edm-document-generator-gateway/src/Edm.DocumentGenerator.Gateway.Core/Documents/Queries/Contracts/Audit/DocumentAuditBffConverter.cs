using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit;

internal static class DocumentAuditBffConverter
{
    internal static DocumentAuditBff ToBff(DocumentAuditDto audit, DocumentConversionContext context)
    {
        var brief = AuditBriefBffConverter.ToBff(audit.Brief, context.Enricher.References);

        DocumentAuditRecordBff[] records = audit.Records.Select(auditRecord => DocumentAuditRecordBffConverter.ToBff(auditRecord, context)).ToArray();

        var result = new DocumentAuditBff
        {
            Brief = brief,
            Records = records
        };

        return result;
    }
}
