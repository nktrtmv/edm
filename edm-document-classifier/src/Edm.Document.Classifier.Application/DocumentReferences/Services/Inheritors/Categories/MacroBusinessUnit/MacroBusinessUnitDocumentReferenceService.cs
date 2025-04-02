using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.ExternalServices.Categories;
using Edm.Document.Classifier.ExternalServices.Categories.Contracts;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Categories.MacroBusinessUnit;

[UsedImplicitly]
internal sealed class MacroBusinessUnitDocumentReferenceService(ICategoryClient categoriesClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.MacroBusinessUnit,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Макро Бизнес юнит");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        MacroBusinessUnitEs[] businessUnits = await categoriesClient.GetAllMacroBusinessUnits(cancellationToken);

        if (searchParams.Ids.Length != 0)
        {
            businessUnits = businessUnits.Where(b => searchParams.Ids.Contains(b.Id.ToString())).ToArray();
        }
        else
        {
            businessUnits = businessUnits
                .Where(b => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, b.Name))
                .Skip(searchParams.Skip)
                .Take(searchParams.Limit)
                .ToArray();
        }

        DocumentReferenceValue[] result = businessUnits
            .Select(b => new DocumentReferenceValue(b.Id.ToString(), b.Name, string.Empty, b))
            .ToArray();

        return result;
    }
}
