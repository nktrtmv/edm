using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.Values;

internal static class DocumentReferenceValueConverter
{
    internal static DocumentReferenceValueDto FromInternal(DocumentReferenceValueInternal value)
    {
        var result = new DocumentReferenceValueDto
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue
        };

        return result;
    }
}
