namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts;

internal sealed class DocumentClassificationDb
{
    public string DocumentTemplateId { get; init; } = null!;
    public byte[] Data { get; init; } = null!;
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
    public string DataForSearch { get; init; } = null!;
}
