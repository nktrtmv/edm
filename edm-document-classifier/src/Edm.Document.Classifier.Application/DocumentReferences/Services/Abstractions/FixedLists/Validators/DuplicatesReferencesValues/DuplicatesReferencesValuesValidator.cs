using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists.Validators.DuplicatesReferencesValues;

internal static class DuplicatesReferencesValuesValidator
{
    internal static void Validate(DocumentReferenceValue[] values, DocumentReferenceType type)
    {
        string[] duplicatedValuesIds = values
            .GroupBy(v => v.Id)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();

        if (duplicatedValuesIds.Length == 0)
        {
            return;
        }

        string duplicatedValuesIdsString = string.Join(", ", duplicatedValuesIds);

        throw new ApplicationException(
            $"""
             Duplicates references values ids was found.
             ReferenceTypeId: {type.Id}
             DuplicatesValuesIds: {duplicatedValuesIdsString}
             """);
    }
}
