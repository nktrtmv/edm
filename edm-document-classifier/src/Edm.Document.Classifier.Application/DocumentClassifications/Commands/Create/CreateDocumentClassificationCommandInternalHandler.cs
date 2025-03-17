using Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create;

[UsedImplicitly]
internal sealed class CreateDocumentClassificationCommandInternalHandler
    : IRequestHandler<CreateDocumentClassificationCommandInternal, CreateDocumentClassificationCommandInternalResponse>
{
    private readonly IDocumentClassificationRepository _documentClassificationRepository;
    private readonly IDocumentClassifierRepository _documentClassifierRepository;

    public CreateDocumentClassificationCommandInternalHandler(
        IDocumentClassifierRepository documentClassifierRepository,
        IDocumentClassificationRepository documentClassificationRepository)
    {
        _documentClassifierRepository = documentClassifierRepository;
        _documentClassificationRepository = documentClassificationRepository;
    }

    public async Task<CreateDocumentClassificationCommandInternalResponse> Handle(
        CreateDocumentClassificationCommandInternal request,
        CancellationToken cancellationToken)
    {
        DocumentClassifier sample = await _documentClassifierRepository.Get(cancellationToken);

        DocumentClassifierSubset documentClassifierSubset = ClassifierPatternInternalConverter.ToDomain(request.DocumentClassifierSubset);

        DocumentClassification documentClassification = DocumentClassificationFactory.Create(sample, documentClassifierSubset, request.Name);

        await _documentClassificationRepository.Upsert(documentClassification, cancellationToken);

        return new CreateDocumentClassificationCommandInternalResponse(documentClassification.DocumentTemplateId.ToString());
    }
}
