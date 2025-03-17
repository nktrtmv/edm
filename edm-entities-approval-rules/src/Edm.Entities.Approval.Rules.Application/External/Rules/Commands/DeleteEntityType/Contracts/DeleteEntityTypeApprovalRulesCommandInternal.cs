using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.DeleteEntityType.Contracts;

public sealed record DeleteEntityTypeApprovalRulesCommandInternal(EntityTypeKeyInternal EntityTypeKey, string CurrentUserId) : IRequest;
