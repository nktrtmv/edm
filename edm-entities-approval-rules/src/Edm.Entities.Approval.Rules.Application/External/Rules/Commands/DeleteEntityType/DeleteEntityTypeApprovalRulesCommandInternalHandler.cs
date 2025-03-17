using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.DeleteEntityType.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.DeleteEntityType;

[UsedImplicitly]
internal sealed class DeleteEntityTypeApprovalRulesCommandInternalHandler(ApprovalRulesFacade rules)
    : IRequestHandler<DeleteEntityTypeApprovalRulesCommandInternal>
{
    public async Task Handle(DeleteEntityTypeApprovalRulesCommandInternal request, CancellationToken cancellationToken)
    {
        EntityTypeKey key = EntityTypeKeyInternalConverter.ToDomain(request.EntityTypeKey);

        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);

        await rules.Delete(key, currentUserId, cancellationToken);
    }
}
