using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Documents.Generator;

public sealed class DocumentGeneratorDocumentUpdate
{
    public DocumentGeneratorDocumentUpdate(Id<User> currentUserId, DocumentUpdateParameters parameters)
    {
        CurrentUserId = currentUserId;
        Parameters = parameters;
    }

    public Id<User> CurrentUserId { get; }
    public DocumentUpdateParameters Parameters { get; }
}
