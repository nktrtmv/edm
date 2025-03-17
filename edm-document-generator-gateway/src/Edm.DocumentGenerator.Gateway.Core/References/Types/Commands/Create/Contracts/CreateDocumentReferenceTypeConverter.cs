using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

internal static class CreateDocumentReferenceTypeConverter
{
    public static CreateDocumentReferenceType ToDto(CreateReferenceCommandBff request)
    {
        var result = new CreateDocumentReferenceType
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            DisplayName = request.DisplayName,
            ParentReferenceTypes = { request.ReferenceTypes }
        };

        return result;
    }
}
