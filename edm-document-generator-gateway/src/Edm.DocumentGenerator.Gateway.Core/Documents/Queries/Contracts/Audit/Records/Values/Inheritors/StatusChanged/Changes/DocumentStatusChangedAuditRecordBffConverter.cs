using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes;

internal static class DocumentStatusChangedAuditRecordBffConverter
{
    public static DocumentStatusChangedAuditRecordBff ToBff(DocumentStatusChangedAuditRecordDto record, DocumentConversionContext context)
    {
        var change = DocumentStatusChangedAuditRecordChangeBffConverter.ToBff(record.Change);

        DocumentAuditStatusTransitionParameterValueBff[] statusTransitionParametersValues = record.StatusTransitionParametersValues
            .Select(v => DocumentAuditStatusTransitionParameterValueBffFromDtoConverter.FromDto(v, context))
            .ToArray();

        var result = new DocumentStatusChangedAuditRecordBff
        {
            Change = change,
            StatusTransitionParametersValues = statusTransitionParametersValues
        };

        return result;
    }
}
