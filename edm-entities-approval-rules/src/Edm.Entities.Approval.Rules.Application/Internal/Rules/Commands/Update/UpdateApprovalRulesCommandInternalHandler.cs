using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateApprovalRulesCommandInternalHandler : IRequestHandler<UpdateApprovalRulesCommandInternal, UpdateApprovalRulesCommandResponseInternal>
{
    public UpdateApprovalRulesCommandInternalHandler(IApprovalRulesRepository rules, ApprovalRulesUpdaterService updaterService)
    {
        UpdaterService = updaterService;
    }

    private ApprovalRulesUpdaterService UpdaterService { get; }

    public async Task<UpdateApprovalRulesCommandResponseInternal> Handle(UpdateApprovalRulesCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRuleKey[] keys = request.Keys.Select(ApprovalRuleKeyInternalConverter.ToDomain).ToArray();

        ApprovalRulesUpdateAction action = UpdateApprovalRulesCommandActionInternalConverter.ToDomain(request.Action);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal[] failedDuringUpdateApprovalRules =
            await UpdaterService.Update(keys, action, request.IsDryRun, request.IsActivationRequired, request.Comment, currentUserId, cancellationToken);

        var result = new UpdateApprovalRulesCommandResponseInternal(failedDuringUpdateApprovalRules);

        return result;
    }
}
