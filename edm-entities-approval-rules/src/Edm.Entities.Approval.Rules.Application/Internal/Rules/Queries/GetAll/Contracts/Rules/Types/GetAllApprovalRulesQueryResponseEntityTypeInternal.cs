using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules.Types;

public sealed record GetAllApprovalRulesQueryResponseEntityTypeInternal(
    EntityTypeKeyInternal Key,
    string DisplayName,
    bool IsActive);
