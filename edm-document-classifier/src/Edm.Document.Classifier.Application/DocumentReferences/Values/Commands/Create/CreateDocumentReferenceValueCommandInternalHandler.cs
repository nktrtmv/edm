using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Converters;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create;

[UsedImplicitly]
internal sealed class CreateDocumentReferenceValueCommandInternalHandler(
    IDocumentReferenceValueRepository documentReferenceValueRepository)
    : IRequestHandler<CreateDocumentReferenceValueCommandInternal, CreateDocumentReferenceValueCommandResponseInternal>
{
    public async Task<CreateDocumentReferenceValueCommandResponseInternal> Handle(
        CreateDocumentReferenceValueCommandInternal request,
        CancellationToken cancellationToken)
    {
        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        Id<ReferenceValue>? id = NullableConverter.Convert(request.Id, IdConverterFrom<ReferenceValue>.From);

        ReferenceValue value = DocumentReferenceValueFactory.CreateNew(
            referenceTypeId,
            request.DisplayValue,
            request.DisplaySubValue,
            request.IsHidden,
            currentUserId,
            id);

        await documentReferenceValueRepository.Insert(value, cancellationToken);

        Id<ReferenceValueInternal> idInternal = IdConverterFrom<ReferenceValueInternal>.From(value.Id);

        return new CreateDocumentReferenceValueCommandResponseInternal(idInternal);
    }
}
