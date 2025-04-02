using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.Document.Searcher.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.ApprovalRuleKeys.EntityTypeKeys;

internal static class EntityTypeKeyConverter
{
    internal static EntityTypeKeyDto FromInternal(EntityTypeKeyInternal key)
    {
        var result = new EntityTypeKeyDto
        {
            DomainId = key.DomainId,
            EntityTypeId = key.EntityTypeId,
            EntityTypeUpdatedDate = key.EntityTypeUpdatedDate.ToTimestamp()
        };

        return result;
    }
}
