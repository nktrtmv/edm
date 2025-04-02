using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateDocumentReferenceTypeCommandInternalHandler(IDocumentReferenceTypeRepository documentReferenceTypeRepository)
    : IRequestHandler<UpdateDocumentReferenceTypeCommandInternal, UpdateDocumentReferenceTypeCommandResponseInternal>
{
    public async Task<UpdateDocumentReferenceTypeCommandResponseInternal> Handle(
        UpdateDocumentReferenceTypeCommandInternal request,
        CancellationToken cancellationToken)
    {
        DomainId? domainId = string.IsNullOrWhiteSpace(request.DomainId) ? null : DomainId.Parse(request.DomainId);

        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        ReferenceType reference = await documentReferenceTypeRepository.GetRequired(domainId, referenceType, cancellationToken);

        ConcurrencyToken<ReferenceType> concurrencyToken = ConcurrencyTokenConverterFrom<ReferenceType>.From(request.ConcurrencyToken);

        reference.ConcurrencyToken.AssertEqualsTo(concurrencyToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        Id<ReferenceType>[] parentIds = request.ParentIds.Select(IdConverterFrom<ReferenceType>.From).ToArray();

        reference.Update(
            domainId,
            request.DisplayName,
            parentIds,
            currentUserId);

        await documentReferenceTypeRepository.Upsert(reference, cancellationToken);

        var result = new UpdateDocumentReferenceTypeCommandResponseInternal(request.ReferenceType);

        return result;
    }
}
