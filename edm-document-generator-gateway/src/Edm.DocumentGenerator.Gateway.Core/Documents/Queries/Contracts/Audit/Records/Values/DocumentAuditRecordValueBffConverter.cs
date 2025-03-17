using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.Created;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values;

internal static class DocumentAuditRecordValueBffConverter
{
    public static DocumentAuditRecordValueBff ValueToBff(DocumentAuditRecordDto record, DocumentConversionContext context)
    {
        DocumentAuditRecordValueBff result = record.ValueCase switch
        {
            DocumentAuditRecordDto.ValueOneofCase.AsAttributeValuesChanged =>
                DocumentAttributesValuesChangedAuditRecordBffConverter.ToBff(record.AsAttributeValuesChanged, context),

            DocumentAuditRecordDto.ValueOneofCase.AsDocumentCreated =>
                DocumentCreatedAuditRecordBffConverter.ToBff(record.AsDocumentCreated, context),

            DocumentAuditRecordDto.ValueOneofCase.AsStatusChanged =>
                DocumentStatusChangedAuditRecordBffConverter.ToBff(record.AsStatusChanged, context),

            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        return result;
    }
}
