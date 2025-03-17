using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

internal static class CreateReferenceCommandResponseBffConverter
{
    public static CreateReferenceCommandResponseBff FromDto(CreateDocumentReferenceTypeCommandResponse response)
    {
        var result = new CreateReferenceCommandResponseBff
        {
            ReferenceType = response.ReferenceType
        };

        return result;
    }
}
