using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Discriminator;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

[DiscriminatorType<GetAllDocumentsQueryFilterValueBffDiscriminator>]
[JsonDerivedType(typeof(SearchDocumentsQueryFilterBooleanValueBff), nameof(GetAllDocumentsQueryFilterValueBffDiscriminator.Boolean))]
[JsonDerivedType(typeof(SearchDocumentsQueryFilterDateValueBff), nameof(GetAllDocumentsQueryFilterValueBffDiscriminator.Date))]
[JsonDerivedType(typeof(SearchDocumentsQueryFilterNumberValueBff), nameof(GetAllDocumentsQueryFilterValueBffDiscriminator.Number))]
[JsonDerivedType(typeof(SearchDocumentsQueryFilterReferenceValueBff), nameof(GetAllDocumentsQueryFilterValueBffDiscriminator.Reference))]
[JsonDerivedType(typeof(SearchDocumentsQueryFilterStringValueBff), nameof(GetAllDocumentsQueryFilterValueBffDiscriminator.String))]
public abstract class SearchDocumentsQueryFilterValueBff
{
}
