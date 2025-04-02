using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Descriminator;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues;

[DiscriminatorType<GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator>]
[JsonDerivedType(
    typeof(GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBff),
    nameof(GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator.Boolean))]
[JsonDerivedType(typeof(GetAllDocumentsQueryResponseDocumentDateAttributeValueBff), nameof(GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator.Date))]
[JsonDerivedType(typeof(GetAllDocumentsQueryResponseDocumentNumberAttributeValueBff), nameof(GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator.Number))]
[JsonDerivedType(
    typeof(GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff),
    nameof(GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator.Reference))]
[JsonDerivedType(typeof(GetAllDocumentsQueryResponseDocumentStringAttributeValueBff), nameof(GetAllDocumentsQueryResponseDocumentAttributeValueBffDiscriminator.String))]
[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public string RegistryRoleId { get; init; } = string.Empty;

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
