namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed class UnvalidatedDocumentRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Display { get; set; }

    public List<UnvalidatedMarkAttributeWithRoleCondition>? MarkAttributeWithRoleConditions { get; set; }
}
