using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Types;
using Edm.Document.Searcher.GenericSubdomain.Swagger.Attributes;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters;

[DiscriminatorType<DocumentStatusParameterInternalType>]
[JsonDerivedType(typeof(BooleanDocumentStatusParameterInternal), nameof(DocumentStatusParameterInternalType.Boolean))]
[JsonDerivedType(typeof(StringDocumentStatusParameterInternal), nameof(DocumentStatusParameterInternalType.String))]
[JsonDerivedType(typeof(ReferenceAttributeDocumentStatusParameterInternal), nameof(DocumentStatusParameterInternalType.ReferenceAttribute))]
[JsonDerivedType(typeof(DocumentStatusDocumentStatusParameterInternal), nameof(DocumentStatusParameterInternalType.DocumentStatus))]
public abstract class DocumentStatusParameterInternal
{
    public required string Kind { get; init; }

    public string? DisplayName { get; set; }
}
