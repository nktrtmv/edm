using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.ValidateThereAreActiveGraphs.Contracts;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Validators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.ValidateThereAreActiveGraphs;

[UsedImplicitly]
internal sealed class ValidateThereAreActiveGraphsApprovalRulesQueryInternalHandler : IRequestHandler<ValidateThereAreActiveGraphsApprovalRulesQueryInternal>
{
    public ValidateThereAreActiveGraphsApprovalRulesQueryInternalHandler(IApprovalRulesRepository approvalRules)
    {
        ApprovalRules = approvalRules;
    }

    private IApprovalRulesRepository ApprovalRules { get; }

    public async Task Handle(ValidateThereAreActiveGraphsApprovalRulesQueryInternal request, CancellationToken cancellationToken)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyInternalConverter.ToDomain(request.EntityTypeKey);

        ApprovalRule rule = await ApprovalRules.GetRequiredActive(entityTypeKey, cancellationToken);

        ThereAreActiveGraphsForAllTagsApprovalRuleValidator.Validate(rule, request.ApprovalGraphsTags);
    }
}
