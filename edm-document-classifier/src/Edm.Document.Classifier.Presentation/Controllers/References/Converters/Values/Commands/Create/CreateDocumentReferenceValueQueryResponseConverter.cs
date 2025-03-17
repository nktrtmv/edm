using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Create;

internal static class CreateDocumentReferenceValueCommandResponseConverter
{
    public static CreateDocumentReferenceValueCommandResponse FromInternal(CreateDocumentReferenceValueCommandResponseInternal response)
    {
        var result = new CreateDocumentReferenceValueCommandResponse
        {
            Id = response.Id.Value
        };

        return result;
    }
}
