using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

public sealed class GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff : GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public required ReferenceTypeValueBff[] Values { get; init; }

    public string? ReferenceType { get; set; }

    public List<GetAllDocumentsQueryResponseDocumentParentReferenceAttributeValueBff>? Parents { get; set; }
}
