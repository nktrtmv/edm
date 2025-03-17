using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.ShortestPathToCompletion;

public static class DocumentShortestPathToCompletionDetect
{
    public static DocumentStatus[] Detect(DocumentStatusStateMachine statusStateMachine, DocumentStatus fromStatus)
    {
        var visited = new HashSet<Id<DocumentStatus>> { fromStatus.Id };
        var queue = new Queue<DocumentStatus>();
        var predecessors = new Dictionary<Id<DocumentStatus>, DocumentStatus>();

        queue.Enqueue(fromStatus);

        while (queue.Any())
        {
            DocumentStatus currentStatus = queue.Dequeue();

            if (currentStatus.Type == DocumentStatusType.Completed)
            {
                DocumentStatus[] result = DetectPath(fromStatus, currentStatus, predecessors);

                return result;
            }

            DocumentStatusTransition[] availableTransitions = statusStateMachine.GetAvailableTransitionsForStatus(currentStatus.Id);

            foreach (DocumentStatusTransition transition in availableTransitions)
            {
                if (transition.To.Type is DocumentStatusType.Cancelled || visited.Contains(transition.To.Id))
                {
                    continue;
                }

                visited.Add(transition.To.Id);
                predecessors[transition.To.Id] = currentStatus;
                queue.Enqueue(transition.To);
            }
        }

        return Array.Empty<DocumentStatus>();
    }

    private static DocumentStatus[] DetectPath(DocumentStatus startStatus, DocumentStatus currentStatus, Dictionary<Id<DocumentStatus>, DocumentStatus> predecessors)
    {
        var path = new LinkedList<DocumentStatus>();

        while (currentStatus != startStatus)
        {
            path.AddFirst(currentStatus);
            currentStatus = predecessors[currentStatus.Id];
        }

        path.AddFirst(startStatus);

        return path.ToArray();
    }
}
