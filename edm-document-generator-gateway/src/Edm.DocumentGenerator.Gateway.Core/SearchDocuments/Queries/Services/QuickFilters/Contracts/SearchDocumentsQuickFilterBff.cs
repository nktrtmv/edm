using System.Text.Json.Serialization;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters.Contracts;

[JsonDerivedType(typeof(SearchDocumentsMineQuickFilterBff), nameof(SearchDocumentsMineQuickFilterBff))]
[JsonDerivedType(typeof(SearchDocumentsMineTeamQuickFilterBff), nameof(SearchDocumentsMineTeamQuickFilterBff))]
public abstract record SearchDocumentsQuickFilterBff;
