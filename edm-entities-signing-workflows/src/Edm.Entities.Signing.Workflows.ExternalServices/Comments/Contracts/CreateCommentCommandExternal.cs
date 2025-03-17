using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.Comments.Contracts;

public sealed class CreateCommentCommandExternal
{
    public CreateCommentCommandExternal(
        Id<EntityExternal> entityId,
        Id<UserExternal> authorId,
        string subject,
        string text)
    {
        EntityId = entityId;
        AuthorId = authorId;
        Subject = subject;
        Text = text;
    }

    public Id<EntityExternal> EntityId { get; }
    public Id<UserExternal> AuthorId { get; }
    public string Subject { get; }
    public string Text { get; }
}
