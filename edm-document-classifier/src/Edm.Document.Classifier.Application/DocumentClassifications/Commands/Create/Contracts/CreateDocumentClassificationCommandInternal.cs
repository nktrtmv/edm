using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;

public sealed class CreateDocumentClassificationCommandInternal : IRequest<CreateDocumentClassificationCommandInternalResponse>
{
    public CreateDocumentClassificationCommandInternal(string name, DocumentClassifierSubsetInternal documentClassifierSubset)
    {
        Name = name;
        DocumentClassifierSubset = documentClassifierSubset;
    }

    public string Name { get; }
    public DocumentClassifierSubsetInternal DocumentClassifierSubset { get; }
}
