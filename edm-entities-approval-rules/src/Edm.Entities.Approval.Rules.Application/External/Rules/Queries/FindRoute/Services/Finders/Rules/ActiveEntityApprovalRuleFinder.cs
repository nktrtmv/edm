using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Services.Finders.Rules;

internal sealed class ActiveEntityApprovalRuleFinder
{
    public ActiveEntityApprovalRuleFinder(IApprovalRulesRepository rules)
    {
        Rules = rules;
    }

    private IApprovalRulesRepository Rules { get; }

    internal async Task<ApprovalRule> Find(Entity entity, CancellationToken cancellationToken)
    {
        try
        {
            ApprovalRule result = await Rules.GetRequiredActive(entity.TypeKey, cancellationToken);

            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Active approval rule version is not found.\nEntity: {entity}", e);
        }
    }
}
