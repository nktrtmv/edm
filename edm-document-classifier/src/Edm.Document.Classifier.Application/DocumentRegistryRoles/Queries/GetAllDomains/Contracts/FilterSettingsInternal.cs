using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

public sealed record FilterSettingsInternal(bool AllowForSearch, bool ShowInFilters, bool AllowMultipleValues, SearchKind? SearchKind, long? Order);
