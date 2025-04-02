using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.ShortestPathToCompletion;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Boolean;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StagesTypes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StagesTypes;

internal static class DocumentStageTypeDetector
{
    internal static DocumentStageType Detect(DocumentStatusStateMachine statusStateMachine, DocumentStatus status)
    {
        DocumentStageType result =
            TryDirectMapStatusToStage(status.Type) ??
            TryDetectFromStatus(status) ??
            DetectFromShortestPathToCompletion(statusStateMachine, status);

        return result;
    }

    private static DocumentStageType DetectFromShortestPathToCompletion(DocumentStatusStateMachine statusStateMachine, DocumentStatus status)
    {
        DocumentStatus[]? shortestPathToCompletion = DocumentShortestPathToCompletionDetect.Detect(statusStateMachine, status);

        if (shortestPathToCompletion.Length == 0)
        {
            return DocumentStageType.Cancelled;
        }

        DocumentStageType result = shortestPathToCompletion switch
        {
            _ when shortestPathToCompletion.Any(s => s.Type == DocumentStatusType.Approval) => DocumentStageType.ApprovalPreparation,
            _ => DocumentStageType.SigningPreparation
        };

        return result;
    }

    private static DocumentStageType? TryDirectMapStatusToStage(DocumentStatusType statusType)
    {
        DocumentStageType? result = statusType switch
        {
            DocumentStatusType.Initial => DocumentStageType.Draft,
            DocumentStatusType.Backlog => DocumentStageType.Backlog,
            DocumentStatusType.Simple => null,
            DocumentStatusType.Approval => DocumentStageType.Approval,
            DocumentStatusType.Signing => DocumentStageType.Signing,
            DocumentStatusType.Completed => DocumentStageType.InEffect,
            DocumentStatusType.Cancelled => DocumentStageType.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(statusType)
        };

        return result;
    }

    private static DocumentStageType? TryDetectFromStatus(DocumentStatus status)
    {
        bool isBacklogSet = BooleanStatusParameterDetector.IsSet(status, DocumentStatusParameterKind.IsBacklog);

        DocumentStageType? result = isBacklogSet
            ? DocumentStageType.Backlog
            : null;

        return result;
    }
}
