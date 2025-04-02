using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;

internal static class UpdateReferenceValueCommandResponseBffConverter
{
    public static UpdateReferenceValueCommandResponseBff FromDto(UpdateDocumentReferenceValueCommandResponse response)
    {
        var result = new UpdateReferenceValueCommandResponseBff
        {
            Id = response.Id
        };

        return result;
    }
}
