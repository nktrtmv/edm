using Edm.Entities.Approval.Rules.Gateway.Core.Contracts;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Services;

public sealed class UserService(IHttpContextAccessor httpContextAccessor)
{
    public UserBff GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            return new UserBff("0", "nartemov");
        }

        throw new ApplicationException();
    }
}
