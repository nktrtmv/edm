using Edm.DocumentGenerator.Gateway.Presentation.Services;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Presentation.Users;

public sealed class UsersService(IHttpContextAccessor httpContextAccessor)
{
    public UserBff GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            throw new ApplicationException("Can't get current user");
        }

        var login = UserClaimsService.GetLogin(user);
        HashSet<string> roles = UserClaimsService.GetRoles(user);
        var userId = UserClaimsService.GetUserId(user);

        var isAdmin = roles.Contains(SharedRoles.Admin);
        var isAuditor = roles.Contains(SharedRoles.Auditor);

        var result = new UserBff(userId ?? "", login, roles, isAdmin, isAuditor);

        return result;
    }
}
