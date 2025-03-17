using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;

internal static class CreateReferenceValueCommandResponseBffConverter
{
    public static CreateReferenceValueCommandResponseBff FromDto(CreateDocumentReferenceValueCommandResponse response)
    {
        var result = new CreateReferenceValueCommandResponseBff
        {
            Id = response.Id
        };

        return result;
    }
}
