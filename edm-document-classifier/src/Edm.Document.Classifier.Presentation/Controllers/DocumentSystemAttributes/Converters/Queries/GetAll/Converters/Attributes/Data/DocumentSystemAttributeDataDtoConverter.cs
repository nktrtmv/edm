using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Abstractions.Data;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll.Converters.Attributes.Data;

internal static class DocumentSystemAttributeDataDtoConverter
{
    internal static DocumentSystemAttributeDataDto FromInternal(DocumentSystemAttributeDataInternal data)
    {
        var result = new DocumentSystemAttributeDataDto
        {
            Id = data.Id,
            IsArray = data.IsArray,
            SystemName = data.SystemName,
            DisplayName = data.DisplayName,
            DocumentRolesIds = { data.DocumentRolesIds },
            RegistryRolesIds = { data.RegistryRolesIds }
        };

        return result;
    }
}
