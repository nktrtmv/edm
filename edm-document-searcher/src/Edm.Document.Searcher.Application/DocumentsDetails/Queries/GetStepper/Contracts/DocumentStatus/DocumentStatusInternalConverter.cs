using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;

internal static class DocumentStatusInternalConverter
{
    internal static DocumentStatusInternal ToInternal(DocumentStatusExternal status)
    {
        DocumentStatusTypeInternal type = DocumentStatusTypeInternalConverter.FromExternal(status.Type);

        DocumentStatusParameterInternal[] parameters = status.Parameters.Select(DocumentStatusParameterInternalConverter.FromExternal).ToArray();

        var result = new DocumentStatusInternal(status.Id.Value, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
