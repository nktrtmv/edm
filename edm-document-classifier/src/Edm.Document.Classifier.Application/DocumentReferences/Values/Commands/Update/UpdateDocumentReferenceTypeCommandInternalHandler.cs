using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Converters;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateDocumentReferenceValueCommandInternalHandler(
    IDocumentReferenceValueRepository documentReferenceValueRepository)
    : IRequestHandler<UpdateDocumentReferenceValueCommandInternal, UpdateDocumentReferenceValueCommandResponseInternal>
{
    public async Task<UpdateDocumentReferenceValueCommandResponseInternal> Handle(
        UpdateDocumentReferenceValueCommandInternal request,
        CancellationToken cancellationToken)
    {
        Id<ReferenceValue> id = IdConverterFrom<ReferenceValue>.From(request.Id);

        Id<ReferenceValue>? newId = NullableConverter.Convert(request.NewId, IdConverterFrom<ReferenceValue>.From);

        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        var value = await documentReferenceValueRepository.GetRequired(referenceTypeId, id, cancellationToken);

        ConcurrencyToken<ReferenceValue> concurrencyToken = ConcurrencyTokenConverterFrom<ReferenceValue>.From(request.ConcurrencyToken);

        value.ConcurrencyToken.AssertEqualsTo(concurrencyToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        value.Update(
            request.DisplayValue,
            request.DisplaySubValue,
            request.IsHidden,
            currentUserId);

        await documentReferenceValueRepository.Update(value, newId, cancellationToken);

        return new UpdateDocumentReferenceValueCommandResponseInternal(request.NewId ?? request.Id);
    }
}
