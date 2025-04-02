using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes;

internal static class DocumentAttributesValuesChangedAuditRecordChangeBffConverter
{
    public static DocumentAttributesValuesChangedAuditRecordChangeBff ToBff(DocumentAttributesValuesChangedAuditRecordChangeDto change, DocumentConversionContext context)
    {
        var from = DocumentAuditAttributeValueBffConverter.ToBff(change.From, context);
        var to = DocumentAuditAttributeValueBffConverter.ToBff(change.To, context);

        var result = new DocumentAttributesValuesChangedAuditRecordChangeBff
        {
            From = from,
            To = to
        };

        return result;
    }
}
