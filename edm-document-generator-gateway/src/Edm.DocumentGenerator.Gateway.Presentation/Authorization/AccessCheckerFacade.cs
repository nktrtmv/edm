using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Presentation.Authorization;

public sealed class AccessCheckerFacade(UsersService userService)
{
    public void ThrowIfAdminAccessMissing(UserBff? userBff = null)
    {
        ThrowAccessDeniedIfFalse(() => HasAdminAccess(userBff));
    }

    public bool HasAdminAccess(UserBff? userBff = null)
    {
        var user = userBff ?? userService.GetCurrentUser();

        return user.IsAdmin;
    }

    private static void ThrowAccessDeniedIfFalse(Func<bool> func)
    {
        var hasAccess = func();

        if (!hasAccess)
        {
            throw new UnauthorizedAccessException("Access denied");
        }
    }
}
