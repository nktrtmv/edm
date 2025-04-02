using Edm.DocumentGenerators.Domain.Entities.Documents;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts;

public abstract class DocumentNotifierRequestExternal
{
    protected DocumentNotifierRequestExternal(Document document)
    {
        Document = document;
    }

    public Document Document { get; }
}
