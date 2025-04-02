using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

internal static class ReferenceValueBffConverter
{
    public static ReferenceValueBff FromDto(ReferenceValue value)
    {
        var result = new ReferenceValueBff
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue,
            IsHidden = value.IsHidden,
            ConcurrencyToken = value.ConcurrencyToken
        };

        return result;
    }
}
