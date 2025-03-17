using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events;

public interface IDocumentGeneratorEventsSender
{
    Task Send(DocumentGeneratorEvent @event, CancellationToken cancellationToken);
}
