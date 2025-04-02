using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed record UnvalidatedFilterSettings(
    bool AllowForSearch,
    bool ShowInFilters,
    SearchKind SearchKind,
    bool AllowMultipleValues,
    long? Order);
