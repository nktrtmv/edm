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

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Categories;

[UsedImplicitly]
internal sealed class CategoryFirstLevelDocumentReferenceService(ICategoryClient categoriesClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } =
        new DocumentReferenceType(
            DocumentReferenceTypeId.CategoryFirstLevel,
            DocumentReferenceSearchKind.FixedList,
            DocumentReferenceKind.None,
            "Бизнес юнит",
            DocumentReferenceTypeId.MacroBusinessUnit);

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        CategoryEs[] categories;

        if (searchParams.Ids.Length != 0)
        {
            categories = await categoriesClient.GetCategories(searchParams.Ids.Select(long.Parse).ToArray(), cancellationToken);
        }
        else
        {
            string[] macroBuIds = searchParams.Key.ParentValues
                .Where(v => int.Parse(v.ReferenceTypeId.Value) == (int)DocumentReferenceTypeId.MacroBusinessUnit)
                .SelectMany(v => v.Ids)
                .ToArray();

            categories = await categoriesClient.GetCategoriesFirstLevel(macroBuIds.ToArray(), cancellationToken);

            categories = categories
                .Where(c => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, c.Name))
                .Skip(searchParams.Skip)
                .Take(searchParams.Limit)
                .ToArray();
        }

        DocumentReferenceValue[] result = categories.Select(
                c => new DocumentReferenceValue(
                    c.Id.ToString(),
                    c.Name,
                    string.Empty,
                    c))
            .ToArray();

        return result;
    }
}
