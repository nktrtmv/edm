using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Types;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Types;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses;

internal static class DocumentStatusExternalConverter
{
    internal static DocumentStatusExternal FromDto(DocumentStatusDto status, DocumentAuditDto audit)
    {
        Id<DocumentStatusExternal> id = IdConverterFrom<DocumentStatusExternal>.FromString(status.Id);

        DocumentStatusTypeExternal type = DocumentStatusTypeDtoConverter.ToExternal(status.Type);

        UtcDateTime<DocumentStatusExternal> startedDate = FetchStartedDate(status, audit);

        DocumentStatusParameterExternal[] parameters = status.Parameters.Select(DocumentStatusParameterDtoConverter.ToExternal).ToArray();

        var result = new DocumentStatusExternal(id, status.DisplayName, type, startedDate, status.SystemName, parameters);

        return result;
    }

    private static UtcDateTime<DocumentStatusExternal> FetchStartedDate(DocumentStatusDto status, DocumentAuditDto audit)
    {
        Timestamp startedDate = audit.Records
            .Where(r => r.AsStatusChanged is not null)
            .LastOrDefault(s => s.AsStatusChanged.Change.To.Id == status.Id)
            ?.Heading.UpdatedDateTime ?? audit.Brief.UpdatedDateTime;

        UtcDateTime<DocumentStatusExternal> result = UtcDateTimeConverterFrom<DocumentStatusExternal>.FromTimestamp(startedDate);

        return result;
    }
}
