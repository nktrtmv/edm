using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;

public class UpdateDocumentReferenceValueConverter
{
    public static UpdateDocumentReferenceValue ToDto(UpdateReferenceValueCommandBff request)
    {
        var result = new UpdateDocumentReferenceValue
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            Id = request.Id,
            NewId = request.NewId,
            DisplayValue = request.DisplayValue,
            DisplaySubValue = request.DisplaySubValue,
            IsHidden = request.IsHidden
        };

        return result;
    }
}
