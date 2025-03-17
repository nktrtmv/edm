using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes.Contracts.Types;

internal static class ApprovalReferenceTypeConverter
{
    internal static ApprovalReferenceTypeDto ToDto(DocumentReferenceTypeInternal type)
    {
        string id = ReferenceTypeIdConverter.ToDto(type.Id);

        string[] parentIds = type.ParentIds.Select(ReferenceTypeIdConverter.ToDto).ToArray();

        ApprovalReferenceSearchKindDto searchKind = ApprovalReferenceSearchKindConverter.ToDto(type.SearchKind);

        var result = new ApprovalReferenceTypeDto
        {
            Id = id,
            DisplayName = type.DisplayName,
            SearchKind = searchKind,
            ParentIds = { parentIds }
        };

        return result;
    }
}
