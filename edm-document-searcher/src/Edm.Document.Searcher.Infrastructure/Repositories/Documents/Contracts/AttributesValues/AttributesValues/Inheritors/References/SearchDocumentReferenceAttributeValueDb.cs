namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;

internal sealed class SearchDocumentReferenceAttributeValueDb : SearchDocumentAttributeValueDbGeneric<string>
{
    /// <summary>
    /// Переопределенное значение справочника для атрибута
    /// </summary>
    public string? ReferenceType { get; set; }

    public List<SearchDocumentParentReferenceAttributeValueDb>? SearchDocumentParent { get; set; }
}
