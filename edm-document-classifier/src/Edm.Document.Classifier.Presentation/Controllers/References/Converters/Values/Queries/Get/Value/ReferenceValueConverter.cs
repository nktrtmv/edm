using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get.Value;

internal static class ReferenceValueConverter
{
    public static ReferenceValue FromInternal(ReferenceValueInternal value)
    {
        string concurrencyToken = ConcurrencyTokenConverterTo.ToString(value.ConcurrencyToken);

        var result = new ReferenceValue
        {
            Id = value.Id.Value,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue,
            IsHidden = value.IsHidden,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
