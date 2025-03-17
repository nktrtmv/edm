using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion;

public sealed class CreateNewVersionApprovalRulesCommandService : ApprovalRulesServiceBase
{
    public CreateNewVersionApprovalRulesCommandService(ApprovalRulesService.ApprovalRulesServiceClient rules) : base(rules)
    {
    }

    public async Task<CreateNewVersionApprovalRulesCommandResponseBff> CreateNewVersion(
        CreateNewVersionApprovalRulesCommandBff command,
        string currentUserId,
        CancellationToken cancellationToken)
    {
        var request =
            CreateNewVersionApprovalRulesCommandBffConverter.ToDto(command, currentUserId);

        var response =
            await Rules.CreateNewVersionAsync(request, cancellationToken: cancellationToken);

        var result =
            CreateNewVersionApprovalRulesCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
