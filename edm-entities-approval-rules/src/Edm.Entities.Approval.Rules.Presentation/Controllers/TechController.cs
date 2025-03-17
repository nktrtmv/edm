using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers;

[ApiController]
[Route("api/tech/[action]")]
public class TechController(ApprovalRulesFacade approvalRulesFacade) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetApprovalRuleById(string domainId, string entityId, DateTime utcTime, int version, CancellationToken cancellationToken)
    {
        DomainId domainIdValue = DomainId.Parse(domainId);
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.FromString(entityId);
        UtcDateTime<EntityTypeInternal> time = UtcDateTimeConverterFrom<EntityTypeInternal>.FromUtcDateTime(utcTime);
        var internalKey = new EntityTypeKeyInternal(domainIdValue, entityTypeId, time);
        var ruleKey = new ApprovalRuleKeyInternal(internalKey, version);

        ApprovalRule rule = await approvalRulesFacade.GetRequired(ruleKey, cancellationToken);

        return Ok(rule);
    }
}
