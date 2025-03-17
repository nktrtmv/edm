using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Preparers.Publish.Converters.Rules;

internal static class EntitiesApprovalRuleEntityExternalConverter
{
    internal static EntitiesApprovalRuleEntityExternal FromDomain(Document document)
    {
        Id<DocumentTemplate> entityTypeId = document.TemplateId;

        UtcDateTime<DocumentTemplate> entityTypeVersion = document.ApprovalData.AttributesVersion;

        var key = new EntitiesApprovalRuleEntityTypeKeyExternal(entityTypeId, document.DomainId, entityTypeVersion);

        var result = new EntitiesApprovalRuleEntityExternal(key, document.AttributesValues);

        return result;
    }
}
