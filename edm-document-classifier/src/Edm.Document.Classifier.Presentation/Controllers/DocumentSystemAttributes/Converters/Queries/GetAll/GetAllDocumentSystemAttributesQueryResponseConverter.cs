using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll.Converters.Attributes;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll;

internal static class GetAllDocumentSystemAttributesQueryResponseConverter
{
    internal static GetAllDocumentSystemAttributesQueryResponse FromInternal(GetAllDocumentSystemAttributesQueryInternalResponse response)
    {
        DocumentSystemAttributeDto[] attributes =
            response.Attributes.Select(DocumentAttributeDtoFromInternalConverter.FromInternal).ToArray();

        var result = new GetAllDocumentSystemAttributesQueryResponse
        {
            Attributes = { attributes }
        };

        return result;
    }
}
