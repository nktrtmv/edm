using Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Commands.Create;

internal static class CreateDocumentReferenceTypeCommandResponseConverter
{
    public static CreateDocumentReferenceTypeCommandResponse FromInternal(CreateDocumentReferenceTypeCommandResponseInternal response)
    {
        string referenceType = ReferenceTypeIdConverter.ToDto(response.ReferencesType);

        var result = new CreateDocumentReferenceTypeCommandResponse
        {
            ReferenceType = referenceType
        };

        return result;
    }
}
