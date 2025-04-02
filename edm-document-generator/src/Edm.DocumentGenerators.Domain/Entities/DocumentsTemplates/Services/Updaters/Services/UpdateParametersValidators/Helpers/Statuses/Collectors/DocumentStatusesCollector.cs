using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Collectors;

public static class DocumentStatusesCollector
{
    public static DocumentStatus[] Collect(DocumentStatusTransition[] statusesTransitions)
    {
        IEnumerable<DocumentStatus> fromStatuses = statusesTransitions.Select(t => t.From);
        IEnumerable<DocumentStatus> toStatuses = statusesTransitions.Select(t => t.To);

        DocumentStatus[] result = fromStatuses.Concat(toStatuses).Distinct().ToArray();

        return result;
    }
}
