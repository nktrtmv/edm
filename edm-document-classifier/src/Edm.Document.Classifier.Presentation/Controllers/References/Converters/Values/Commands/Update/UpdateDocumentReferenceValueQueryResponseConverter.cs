using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Commands.Update;

internal static class UpdateDocumentReferenceValueCommandResponseConverter
{
    public static UpdateDocumentReferenceValueCommandResponse FromInternal(UpdateDocumentReferenceValueCommandResponseInternal response)
    {
        var result = new UpdateDocumentReferenceValueCommandResponse
        {
            Id = response.Id.Value
        };

        return result;
    }
}
