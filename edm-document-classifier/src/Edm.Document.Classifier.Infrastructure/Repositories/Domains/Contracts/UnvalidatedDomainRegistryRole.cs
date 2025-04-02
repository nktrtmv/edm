using JetBrains.Annotations;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

[UsedImplicitly]
public sealed class UnvalidatedDomainRegistryRole
{
    public int Id { get; set; }
    public string? Kind { get; set; }
    public string? Name { get; set; }
    public string? Display { get; set; }
    public string? SystemName { get; set; }
    public UnvalidatedRegistrySettings? RegistrySettings { get; set; }
    public UnvalidatedFilterSettings? FilterSettings { get; set; }
    public UnvalidatedTypeSettings? TypeSettings { get; set; }
    public List<UnvalidatedMarkAttributeWithRoleCondition>? AdditionMarkAttributeWithRoleConditions { get; set; }
}
