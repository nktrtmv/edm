using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Update;

internal static class UpdateDocumentReferenceTypeCommandResponseConverter
{
    public static UpdateDocumentReferenceTypeCommandResponse FromInternal(UpdateDocumentReferenceTypeCommandResponseInternal response)
    {
        string referenceType = ReferenceTypeIdConverter.ToDto(response.ReferenceTypeId);

        var result = new UpdateDocumentReferenceTypeCommandResponse
        {
            ReferenceType = referenceType
        };

        return result;
    }
}
