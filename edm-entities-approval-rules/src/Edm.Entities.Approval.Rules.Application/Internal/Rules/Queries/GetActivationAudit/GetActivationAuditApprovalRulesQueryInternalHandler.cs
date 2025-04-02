using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits.Records;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit;

[UsedImplicitly]
internal sealed class GetActivationAuditApprovalRulesQueryInternalHandler
    : IRequestHandler<GetActivationAuditApprovalRulesQueryInternal, GetActivationAuditApprovalRulesQueryResponseInternal>
{
    public GetActivationAuditApprovalRulesQueryInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<GetActivationAuditApprovalRulesQueryResponseInternal> Handle(
        GetActivationAuditApprovalRulesQueryInternal request,
        CancellationToken cancellationToken)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyInternalConverter.ToDomain(request.EntityTypeKey);

        ApprovalRule[] rules = await Rules.GetAllVersions(entityTypeKey, true, cancellationToken);

        ApprovalRuleActivationAuditRecord[] audit = ActivationAuditCollector.Collect(rules);

        ApprovalRuleActivationAuditRecordInternal[] auditInternal = audit.Select(ApprovalRuleActivationAuditRecordInternalConverter.FromDomain).ToArray();

        var result = new GetActivationAuditApprovalRulesQueryResponseInternal(auditInternal);

        return result;
    }
}
