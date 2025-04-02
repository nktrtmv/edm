using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;

internal static class CreateDocumentReferenceValueConverter
{
    public static CreateDocumentReferenceValue ToDto(CreateReferenceValueCommandBff request)
    {
        var result = new CreateDocumentReferenceValue
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            Id = request.Id,
            DisplayValue = request.DisplayValue,
            DisplaySubValue = request.DisplaySubValue,
            IsHidden = request.IsHidden
        };

        return result;
    }
}
