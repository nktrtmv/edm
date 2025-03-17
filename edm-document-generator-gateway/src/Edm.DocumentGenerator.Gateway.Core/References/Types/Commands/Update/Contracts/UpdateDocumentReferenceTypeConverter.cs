using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

internal static class UpdateDocumentReferenceTypeConverter
{
    public static UpdateDocumentReferenceType ToDto(UpdateReferenceCommandBff request)
    {
        var result = new UpdateDocumentReferenceType
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            DisplayName = request.DisplayName,
            ParentReferenceTypes = { request.ReferenceTypes }
        };

        return result;
    }
}
