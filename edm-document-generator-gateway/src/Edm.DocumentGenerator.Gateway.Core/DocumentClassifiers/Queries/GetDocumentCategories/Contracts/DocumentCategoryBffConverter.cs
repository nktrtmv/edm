using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories.Contracts;

internal static class DocumentCategoryBffConverter
{
    public static DocumentCategoryBff ToBff(GetDocumentCategoriesQueryResponseDocumentCategory category)
    {
        var result = new DocumentCategoryBff
        {
            Id = category.Id,
            Description = category.Description,
            Name = category.Name
        };

        return result;
    }
}
