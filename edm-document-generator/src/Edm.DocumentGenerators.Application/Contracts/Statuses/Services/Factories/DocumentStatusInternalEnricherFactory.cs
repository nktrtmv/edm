using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Services.Factories;

internal static class DocumentStatusInternalEnricherFactory
{
    internal static DocumentStatusInternalEnricher Create(Document document)
    {
        DocumentStatusTransition[] transitions = document
            .StatusStateMachine
            .Transitions;

        IEnumerable<DocumentStatus> statuses = transitions.Select(t => t.From)
            .Concat(transitions.Select(t => t.To))
            .DistinctBy(s => s.Id);

        Dictionary<Id<DocumentStatus>, DocumentStatus> statusesById =
            statuses.ToDictionary(x => x.Id);

        var result = new DocumentStatusInternalEnricher(statusesById);

        return result;
    }
}
