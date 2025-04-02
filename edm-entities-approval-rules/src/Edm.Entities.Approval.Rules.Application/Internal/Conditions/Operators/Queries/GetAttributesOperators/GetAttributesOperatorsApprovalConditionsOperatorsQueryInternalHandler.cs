using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Conditions.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators;

[UsedImplicitly]
internal sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryInternalHandler
    : IRequestHandler<GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal,
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal>
{
    public GetAttributesOperatorsApprovalConditionsOperatorsQueryInternalHandler(
        IApprovalRulesRepository rules,
        IApprovalConditionsOperatorsRepository operators)
    {
        Rules = rules;
        Operators = operators;
    }

    private IApprovalConditionsOperatorsRepository Operators { get; }
    private IApprovalRulesRepository Rules { get; }

    public async Task<GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal> Handle(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal request,
        CancellationToken cancellationToken)
    {
        ApprovalRuleKey approvalRuleKey = ApprovalRuleKeyInternalConverter.ToDomain(request.ApprovalRuleKey);

        ApprovalRule rule = await Rules.GetRequired(approvalRuleKey, cancellationToken);

        Dictionary<Type, EntityAttributeValueConditionOperator[]> attributesOperators =
            await Operators.GetAttributesOperators(cancellationToken);

        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal result =
            GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter.FromDomain(attributesOperators, rule);

        return result;
    }
}
