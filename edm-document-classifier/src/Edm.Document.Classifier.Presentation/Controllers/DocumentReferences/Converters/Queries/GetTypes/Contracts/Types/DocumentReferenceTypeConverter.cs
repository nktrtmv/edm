using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes.Contracts.Types.SearchKinds;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes.Contracts.Types;

internal static class DocumentReferenceTypeConverter
{
    internal static DocumentReferenceTypeDto ToDto(DocumentReferenceTypeInternal type)
    {
        string id = ReferenceTypeIdConverter.ToDto(type.Id);

        string[] parentIds = type.ParentIds.Select(ReferenceTypeIdConverter.ToDto).ToArray();

        DocumentReferenceSearchKindDto searchKind = DocumentReferenceSearchKindConverter.ToDto(type.SearchKind);

        var result = new DocumentReferenceTypeDto
        {
            Id = id,
            DisplayName = type.DisplayName,
            SearchKind = searchKind,
            ParentIds = { parentIds }
        };

        return result;
    }
}
