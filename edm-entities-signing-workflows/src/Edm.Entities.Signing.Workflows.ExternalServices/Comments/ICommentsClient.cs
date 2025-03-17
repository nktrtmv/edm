using Edm.Entities.Signing.Workflows.ExternalServices.Comments.Contracts;

namespace Edm.Entities.Signing.Workflows.ExternalServices.Comments;

public interface ICommentsClient
{
    Task CreateComment(CreateCommentCommandExternal request, CancellationToken cancellationToken);
}
