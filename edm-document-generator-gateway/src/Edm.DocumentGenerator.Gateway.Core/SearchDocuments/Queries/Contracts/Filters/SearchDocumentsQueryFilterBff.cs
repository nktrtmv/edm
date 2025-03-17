using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Discriminator;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;

[DiscriminatorType<SearchDocumentsQueryFilterBffDiscriminator>]
[JsonDerivedType(typeof(SearchDocumentsQueryContainsFilterBff), nameof(SearchDocumentsQueryFilterBffDiscriminator.Contains))]
[JsonDerivedType(typeof(SearchDocumentsQueryMatchFilterBff), nameof(SearchDocumentsQueryFilterBffDiscriminator.Match))]
[JsonDerivedType(typeof(SearchDocumentsQueryRangeFilterBff), nameof(SearchDocumentsQueryFilterBffDiscriminator.Range))]
public abstract class SearchDocumentsQueryFilterBff
{
    public required string[] RegistryRolesIds { get; init; }
}
