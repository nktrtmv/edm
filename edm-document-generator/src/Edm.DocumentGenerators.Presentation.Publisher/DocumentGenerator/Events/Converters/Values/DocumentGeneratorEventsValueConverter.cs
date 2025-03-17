using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts.Inheritors.DocumentChanged;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Values.DocumentChanged;

namespace Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Values;

internal static class DocumentGeneratorEventsValueConverter
{
    internal static DocumentGeneratorEventsValue FromDomain(DocumentGeneratorEvent @event)
    {
        DocumentGeneratorEventsValue result = @event switch
        {
            DocumentChangedDocumentGeneratorEvent e => DocumentChangedDocumentGeneratorEventConverter.FromDomain(e),
            _ => throw new ArgumentTypeOutOfRangeException(@event)
        };

        return result;
    }
}
