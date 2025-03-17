using Edm.Document.Classifier.ExternalServices.Categories.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Categories;

public interface ICategoryClient
{
    Task<MacroBusinessUnitEs[]> GetAllMacroBusinessUnits(CancellationToken cancellationToken);
    Task<CategoryEs[]> GetCategoriesFirstLevel(string[] maсroBuIds, CancellationToken cancellationToken);
    Task<CategoryEs[]> GetCategoriesSecondLevel(long[] firstLevelIds, CancellationToken cancellationToken);
    Task<CategoryEs[]> GetCategories(long[] ids, CancellationToken cancellationToken);
}
