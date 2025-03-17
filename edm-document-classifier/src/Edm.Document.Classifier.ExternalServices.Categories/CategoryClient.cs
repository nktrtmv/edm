using Edm.Document.Classifier.ExternalServices.Categories.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Categories;

internal sealed class CategoryClient : ICategoryClient
{
    private static readonly MacroBusinessUnitEs[] MacroBusinessUnits =
    [
        new MacroBusinessUnitEs("1", "macro_bu_1"),
        new MacroBusinessUnitEs("2", "macro_bu_2"),
        new MacroBusinessUnitEs("3", "macro_bu_3")
    ];

    private static readonly CategoryEs[] CategoriesFirstLevel =
    [
        new CategoryEs(11, "category_1_1"),
        new CategoryEs(12, "category_1_2"),
        new CategoryEs(13, "category_1_3"),
        new CategoryEs(21, "category_2_1"),
        new CategoryEs(22, "category_2_2"),
        new CategoryEs(23, "category_2_3"),
        new CategoryEs(31, "category_3_1"),
        new CategoryEs(32, "category_3_2"),
        new CategoryEs(33, "category_3_3")
    ];

    private static readonly CategoryEs[] CategoriesSecondLevel =
    [
        new CategoryEs(111, "category_1_1_1"),
        new CategoryEs(112, "category_1_1_2"),
        new CategoryEs(121, "category_1_2_1"),
        new CategoryEs(122, "category_1_2_2"),
        new CategoryEs(131, "category_1_3_1"),
        new CategoryEs(132, "category_1_3_2"),
        new CategoryEs(211, "category_2_1_1"),
        new CategoryEs(212, "category_2_1_2"),
        new CategoryEs(221, "category_2_2_1"),
        new CategoryEs(222, "category_2_2_2"),
        new CategoryEs(231, "category_2_3_1"),
        new CategoryEs(232, "category_2_3_2"),
        new CategoryEs(311, "category_3_1_1"),
        new CategoryEs(312, "category_3_1_2"),
        new CategoryEs(321, "category_3_2_1"),
        new CategoryEs(322, "category_3_2_2"),
        new CategoryEs(331, "category_3_3_1"),
        new CategoryEs(332, "category_3_3_2")
    ];

    private CategoryEs[] Categories => CategoriesFirstLevel.Concat(CategoriesSecondLevel).ToArray();

    public Task<MacroBusinessUnitEs[]> GetAllMacroBusinessUnits(CancellationToken cancellationToken)
    {
        return Task.FromResult(MacroBusinessUnits);
    }

    public Task<CategoryEs[]> GetCategoriesFirstLevel(string[] maсroBuIds, CancellationToken cancellationToken)
    {
        var result = new List<CategoryEs>();

        foreach (var macroBu in maсroBuIds)
        {
            var categories = CategoriesFirstLevel.Where(c => c.Name.Contains($"category_{macroBu}")).ToArray();

            result.AddRange(categories);
        }

        return Task.FromResult(result.ToArray());
    }

    public Task<CategoryEs[]> GetCategoriesSecondLevel(long[] firstLevelIds, CancellationToken cancellationToken)
    {
        var result = new List<CategoryEs>();

        foreach (var firstLevelId in firstLevelIds)
        {
            var firstLevel = CategoriesFirstLevel.SingleOrDefault(c => c.Id == firstLevelId);

            if (firstLevel is null)
            {
                continue;
            }

            var secondLevel = CategoriesSecondLevel.Where(c => c.Name.Contains(firstLevel.Name)).ToArray();

            result.AddRange(secondLevel);
        }

        return Task.FromResult(result.ToArray());
    }

    public Task<CategoryEs[]> GetCategories(long[] ids, CancellationToken cancellationToken)
    {
        return Task.FromResult(Categories.Where(c => ids.Contains(c.Id)).ToArray());
    }
}
