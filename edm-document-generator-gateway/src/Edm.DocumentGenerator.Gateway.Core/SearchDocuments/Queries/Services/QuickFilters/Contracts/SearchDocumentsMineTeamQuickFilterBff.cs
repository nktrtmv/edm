namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters.Contracts;

public sealed record SearchDocumentsMineTeamQuickFilterBff(bool IsCumulative, string[]? PersonIds) : SearchDocumentsQuickFilterBff;
