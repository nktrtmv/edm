using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged.Changes;

internal static class DocumentStatusChangedAuditRecordChangeDtoConverter
{
    internal static DocumentStatusChangedAuditRecordChangeDto FromInternal(AuditRecordChangeInternal<DocumentStatusInternal> change)
    {
        DocumentStatusDto from = DocumentStatusDtoConverter.FromInternal(change.From);

        DocumentStatusDto to = DocumentStatusDtoConverter.FromInternal(change.To);

        var result = new DocumentStatusChangedAuditRecordChangeDto
        {
            From = from,
            To = to
        };

        return result;
    }
}
