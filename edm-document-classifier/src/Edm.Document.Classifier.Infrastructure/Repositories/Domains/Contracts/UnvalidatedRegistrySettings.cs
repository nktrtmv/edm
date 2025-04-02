namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed record UnvalidatedRegistrySettings(
    bool ShowInRegistry,
    bool ShowByDefault);
