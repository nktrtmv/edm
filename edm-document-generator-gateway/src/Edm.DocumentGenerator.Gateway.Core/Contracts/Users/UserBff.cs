namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

public sealed record UserBff(
    string Id,
    string Login,
    HashSet<string> Roles,
    bool IsAdmin,
    bool IsAuditor);
