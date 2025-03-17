namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed class UnvalidatedSystemAttribute
{
    public int Id { get; set; }

    public string? Display { get; set; }

    public string? SystemName { get; set; }

    public bool IsArray { get; set; }

    public int[]? DocumentRolesIds { get; set; }

    public int[]? RegistryRolesIds { get; set; }

    public UnvalidatedTypeSettings? TypeSettings { get; set; }
}
