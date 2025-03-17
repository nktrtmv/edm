using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Services.Contracts;

internal static class ExtractedUploadReferenceValueConverter
{
    public static BulkUpsertReferenceValue ToDto(ExtractedUploadReferenceValue value)
    {
        var result = new BulkUpsertReferenceValue
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue
        };

        return result;
    }
}
