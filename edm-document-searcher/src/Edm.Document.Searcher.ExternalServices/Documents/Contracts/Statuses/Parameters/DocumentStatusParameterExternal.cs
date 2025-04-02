using System.Text.Json.Serialization;

using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Kinds;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Types;
using Edm.Document.Searcher.GenericSubdomain.Swagger.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;

[DiscriminatorType<DocumentStatusParameterExternalType>]
[JsonDerivedType(typeof(BooleanDocumentStatusParameterExternal), nameof(DocumentStatusParameterExternalType.Boolean))]
[JsonDerivedType(typeof(StringDocumentStatusParameterExternal), nameof(DocumentStatusParameterExternalType.String))]
[JsonDerivedType(typeof(ReferenceAttributeDocumentStatusParameterExternal), nameof(DocumentStatusParameterExternalType.ReferenceAttribute))]
[JsonDerivedType(typeof(DocumentStatusDocumentStatusParameterExternal), nameof(DocumentStatusParameterExternalType.DocumentStatus))]
public abstract class DocumentStatusParameterExternal
{
    public required DocumentStatusParameterKindExternal Kind { get; init; }

    public string? DisplayName { get; set; }
}
