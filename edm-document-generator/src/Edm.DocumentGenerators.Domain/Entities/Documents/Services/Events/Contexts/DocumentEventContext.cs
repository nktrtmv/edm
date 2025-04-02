using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Contexts;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;

public sealed class DocumentEventContext(Document host, Id<User> actorId, IRoleAdapter roleAdapter) : EventContext<Document, User>(host, actorId)
{
    public IRoleAdapter RoleAdapter { get; } = roleAdapter;
}
