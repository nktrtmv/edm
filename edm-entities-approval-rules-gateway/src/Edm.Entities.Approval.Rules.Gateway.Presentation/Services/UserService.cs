using Edm.Entities.Approval.Rules.Gateway.Core.Contracts;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Services;

public sealed class UserService(IHttpContextAccessor httpContextAccessor)
{
    public UserBff GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.Name is "dev-user")
        {
            return new UserBff("00000000-0000-0000-0000-000000000000", "nartemov");
        }

        throw new ApplicationException($"Current user is (identity name: {user?.Identity?.Name}; claims: {string.Join(", ", user?.Claims.Select(c => c.Value) ?? [])})");
    }
}
