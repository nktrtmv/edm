using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentGenerator.Events;

internal static class DocumentGeneratorEventDocumentApplicationEventDbConverter
{
    internal static DocumentGeneratorEventDocumentApplicationEventDb FromDomain(DocumentGeneratorEventDocumentApplicationEvent applicationEvent)
    {
        var result = new DocumentGeneratorEventDocumentApplicationEventDb();

        switch (applicationEvent)
        {
            case DocumentChangedDocumentGeneratorEventDocumentApplicationEvent:
                result.AsDocumentChanged = new DocumentChangedDocumentGeneratorEventDb();

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(applicationEvent);
        }

        return result;
    }

    internal static DocumentGeneratorEventDocumentApplicationEvent ToDomain(DocumentGeneratorEventDocumentApplicationEventDb applicationEvent)
    {
        DocumentGeneratorEventDocumentApplicationEvent result = applicationEvent.EventCase switch
        {
            DocumentGeneratorEventDocumentApplicationEventDb.EventOneofCase.AsDocumentChanged =>
                new DocumentChangedDocumentGeneratorEventDocumentApplicationEvent(),
            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
