using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.Created;

internal static class DocumentCreatedAuditRecordBffConverter
{
    public static DocumentCreatedAuditRecordBff ToBff(DocumentCreatedAuditRecordDto record, DocumentConversionContext context)
    {
        DocumentAttributesValuesChangedAuditRecordChangeBff[] change = record
            .Change
            .Select(x => DocumentAttributesValuesChangedAuditRecordChangeBffConverter.ToBff(x, context))
            .ToArray();

        var result = new DocumentCreatedAuditRecordBff
        {
            Change = change
        };

        return result;
    }
}
