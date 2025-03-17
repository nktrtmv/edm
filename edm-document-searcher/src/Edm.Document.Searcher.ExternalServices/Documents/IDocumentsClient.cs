using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents;

public interface IDocumentsClient
{
    Task<DocumentExternal> Get(Id<DocumentExternal> id, CancellationToken cancellationToken);
}
