using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators.Contracts;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Conditions.Operators;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators;

[UsedImplicitly]
internal sealed class GetLogicalOperatorsApprovalConditionsOperatorsQueryInternalHandler
    : IRequestHandler<GetLogicalOperatorsApprovalConditionsOperatorsQueryInternal, GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal>
{
    public GetLogicalOperatorsApprovalConditionsOperatorsQueryInternalHandler(IApprovalConditionsOperatorsRepository operators)
    {
        Operators = operators;
    }

    private IApprovalConditionsOperatorsRepository Operators { get; }

    public async Task<GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal> Handle(
        GetLogicalOperatorsApprovalConditionsOperatorsQueryInternal request,
        CancellationToken cancellationToken)
    {
        EntityConditionOperator[] operators = await Operators.GetLogicalOperators(cancellationToken);

        GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal result =
            GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter.FromDomain(operators);

        return result;
    }
}
