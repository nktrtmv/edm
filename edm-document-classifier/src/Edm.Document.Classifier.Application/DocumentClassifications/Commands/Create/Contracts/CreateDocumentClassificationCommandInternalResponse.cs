namespace Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;

public sealed class CreateDocumentClassificationCommandInternalResponse
{
    public CreateDocumentClassificationCommandInternalResponse(string documentTemplateId)
    {
        DocumentTemplateId = documentTemplateId;
    }

    public string DocumentTemplateId { get; }
}
