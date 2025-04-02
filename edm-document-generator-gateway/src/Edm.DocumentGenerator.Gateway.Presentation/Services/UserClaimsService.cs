using System.Security.Claims;

namespace Edm.DocumentGenerator.Gateway.Presentation.Services;

internal static class UserClaimsService
{
    private const string DomainIdClaim = "DomainId";
    private const string UserIdClaim = "UserId";

    internal static HashSet<string> GetRoles(ClaimsPrincipal userClaims)
    {
        HashSet<string> result = userClaims
            .Claims
            .Where(a => a.Type == ClaimTypes.Role)
            .Select(a => a.Value)
            .ToHashSet();

        return result;
    }

    internal static string? GetDomainId(ClaimsPrincipal userClaims)
    {
        var result = userClaims
            .Claims
            .FirstOrDefault(a => a.Type == DomainIdClaim)
            ?.Value ?? "8a3d776c-906a-4de2-9c20-1df638f1545b";

        return result;
    }

    internal static string? GetUserId(ClaimsPrincipal userClaims)
    {
        var result = userClaims
            .Claims
            .FirstOrDefault(a => a.Type == UserIdClaim)
            ?.Value ?? "0";

        return result;
    }

    internal static string GetLogin(ClaimsPrincipal userClaims)
    {
        return userClaims.Identity?.Name ?? "nartemov";
    }
}
