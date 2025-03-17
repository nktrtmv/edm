using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create;

[UsedImplicitly]
internal sealed class CreateDocumentReferenceTypeCommandInternalHandler(IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    : IRequestHandler<CreateDocumentReferenceTypeCommandInternal, CreateDocumentReferenceTypeCommandResponseInternal>
{
    private const int InitReferenceId = 100_000;

    public async Task<CreateDocumentReferenceTypeCommandResponseInternal> Handle(
        CreateDocumentReferenceTypeCommandInternal request,
        CancellationToken cancellationToken)
    {
        var currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        DomainId? domainId = string.IsNullOrWhiteSpace(request.DomainId) ? null : DomainId.Parse(request.DomainId);

        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        var referenceTypeId = IdConverterTo.ToInt(request.ReferenceType);

        var reference = await documentReferenceTypeRepository.Get(domainId, referenceType, cancellationToken);

        if (referenceTypeId < InitReferenceId)
        {
            throw new ArgumentException($"Значение referenceType {referenceType} должно превышать {InitReferenceId}");
        }

        if (reference is not null)
        {
            throw new ArgumentException($"Справочник с referenceType {referenceType} уже существует");
        }

        Id<ReferenceType>[] parentIds = request.ParentIds.Select(IdConverterFrom<ReferenceType>.From).ToArray();

        var documentReferenceType = DocumentReferenceTypeFactory.CreateNew(
            domainId,
            referenceType,
            request.DisplayName,
            parentIds,
            currentUserId);

        await documentReferenceTypeRepository.Upsert(documentReferenceType, cancellationToken);

        return new CreateDocumentReferenceTypeCommandResponseInternal(request.ReferenceType);
    }
}
