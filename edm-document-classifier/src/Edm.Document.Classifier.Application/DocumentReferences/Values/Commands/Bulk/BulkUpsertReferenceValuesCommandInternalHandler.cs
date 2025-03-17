using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Converters;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk;

[UsedImplicitly]
internal class BulkUpsertReferenceValuesCommandInternalHandler(
    IDocumentReferenceValueRepository documentReferenceValueRepository): IRequestHandler<BulkUpsertReferenceValuesCommandInternal, BulkUpsertReferenceValuesCommandResponseInternal>
{
    public async Task<BulkUpsertReferenceValuesCommandResponseInternal> Handle(BulkUpsertReferenceValuesCommandInternal request, CancellationToken cancellationToken)
    {
        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);

        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.From(request.ReferenceType);

        Id<ReferenceValue>[] potentiallyExistedValueIds = request.Values
            .Select(v => v.Id)
            .OfType<string>()
            .Select(IdConverterFrom<ReferenceValue>.FromString)
            .ToArray();

        List<ReferenceValue> existedValues = (await documentReferenceValueRepository.GetByIds(referenceTypeId, potentiallyExistedValueIds, cancellationToken)).ToList();

        foreach (ReferenceValue existedValue in existedValues)
        {
            BulkUpsertReferenceValueInternal updatedValue = request.Values.Single(v => existedValue.Id.IsEqualTo(v.Id));

            existedValue.Update(
                updatedValue.DisplayValue,
                updatedValue.DisplaySubValue ?? string.Empty,
                existedValue.IsHidden,
                currentUserId);
        }

        BulkUpsertReferenceValueInternal[] unexistedValuesInternal = request.Values
            .ExceptBy(existedValues.Select(v => IdConverterTo.ToString(v.Id)), v => v.Id)
            .ToArray();

        List<ReferenceValue> unexistedValues = new List<ReferenceValue>(unexistedValuesInternal.Length);

        foreach (BulkUpsertReferenceValueInternal unexistedValue in unexistedValuesInternal)
        {
            Id<ReferenceValue>? id = NullableConverter.Convert(unexistedValue.Id, IdConverterFrom<ReferenceValue>.FromString);

            ReferenceValue value = DocumentReferenceValueFactory.CreateNew(
                referenceTypeId,
                unexistedValue.DisplayValue,
                unexistedValue.DisplaySubValue ?? string.Empty,
                false,
                currentUserId,
                id);

            unexistedValues.Add(value);
        }

        ReferenceValue[] values = existedValues.Concat(unexistedValues).ToArray();

        await documentReferenceValueRepository.BulkUpsert(values, cancellationToken);

        var result = new BulkUpsertReferenceValuesCommandResponseInternal();

        return result;
    }
}
