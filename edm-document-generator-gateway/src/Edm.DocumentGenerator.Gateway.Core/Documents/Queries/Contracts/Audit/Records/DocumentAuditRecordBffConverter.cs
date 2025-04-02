using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Headings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records;

internal static class DocumentAuditRecordBffConverter
{
    public static DocumentAuditRecordBff ToBff(DocumentAuditRecordDto auditRecord, DocumentConversionContext context)
    {
        var result = new DocumentAuditRecordBff
        {
            Heading = AuditRecordHeadingBffConverter.ToBff(auditRecord.Heading, context),
            Value = DocumentAuditRecordValueBffConverter.ValueToBff(auditRecord, context)
        };

        return result;
    }
}
