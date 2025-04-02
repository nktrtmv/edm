using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

internal static class UpdateReferenceCommandResponseBffConverter
{
    public static UpdateReferenceCommandResponseBff FromDto(UpdateDocumentReferenceTypeCommandResponse response)
    {
        var result = new UpdateReferenceCommandResponseBff
        {
            ReferenceType = response.ReferenceType
        };

        return result;
    }
}
