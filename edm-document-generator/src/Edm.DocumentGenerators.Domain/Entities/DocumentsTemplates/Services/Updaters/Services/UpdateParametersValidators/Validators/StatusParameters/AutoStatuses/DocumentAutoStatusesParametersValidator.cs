using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters.AutoStatuses;

internal static class DocumentAutoStatusesParametersValidator
{
    public static void Validate(DocumentStatus status)
    {
        Id<DocumentStatus>? businessErrorHandlingStatusId = DocumentStatusDocumentStatusParameterDetector.GetValueOrNull(
            status,
            DocumentStatusParameterKind.BusinessErrorHandlingStatus);

        if (businessErrorHandlingStatusId == status.Id)
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Business error handling status cannot be equal current status.
                 StatusDisplayName: {status.DisplayName}
                 """);
        }

        Id<DocumentStatus>? unifiedNextAutoStatusId = DocumentStatusDocumentStatusParameterDetector.GetValueOrNull(
            status,
            DocumentStatusParameterKind.UnifiedNextAutoStatus);

        if (unifiedNextAutoStatusId == status.Id)
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Auto status cannot be equal current status.
                 StatusDisplayName: {status.DisplayName}
                 """);
        }
    }
}
