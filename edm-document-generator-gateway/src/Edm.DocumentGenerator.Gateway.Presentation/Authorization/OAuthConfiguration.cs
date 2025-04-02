namespace Edm.DocumentGenerator.Gateway.Presentation.Authorization;

public sealed class OAuthConfiguration
{
    public const string Section = "OAuthConfiguration";

    public string Audience { get; set; } = string.Empty;

    public string Authority { get; set; } = string.Empty;

    public string NameClaimType { get; set; } = "preferred_username";
}
