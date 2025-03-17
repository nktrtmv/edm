using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts;

public sealed class UpsertEntityTypeApprovalRulesCommandInternal : IRequest
{
    public UpsertEntityTypeApprovalRulesCommandInternal(EntityTypeInternal entityType, Id<UserInternal> currentUserId)
    {
        EntityType = entityType;
        CurrentUserId = currentUserId;
    }

    internal EntityTypeInternal EntityType { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
