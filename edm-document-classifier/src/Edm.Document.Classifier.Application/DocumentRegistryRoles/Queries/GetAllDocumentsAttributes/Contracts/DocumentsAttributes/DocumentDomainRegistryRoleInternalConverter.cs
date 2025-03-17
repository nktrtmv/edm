using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts.DocumentsAttributes;

internal static class DocumentDomainRegistryRoleInternalConverter
{
    internal static DomainRegistryRoleInternal FromDomain(DocumentDomainRegistryRole model)
    {
        DocumentRegistryRoleTypeInternal roleType = model.TypeSettings switch
        {
            BooleanTypeSettings => new BooleanDocumentRegistryRoleTypeInternal(),
            ReferenceTypeSettings r => new ReferenceDocumentRegistryRoleTypeInternal(r.Value, r.DisplayType),
            AttachmentTypeSettings => new AttachmentDocumentRegistryRoleTypeInternal(),
            DateTypeSettings d => new DateDocumentRegistryRoleTypeInternal(d.Value),
            StringTypeSettings => new StringDocumentRegistryRoleTypeInternal(),
            NumberTypeSettings n => new NumberDocumentRegistryRoleTypeInternal(n.Precision),
            _ => throw new ArgumentOutOfRangeException(nameof(model.TypeSettings), model.TypeSettings, null)
        };

        var filterSettings = new FilterSettingsInternal(
            model.FilterSettings.AllowForSearch,
            model.FilterSettings.ShowInFilters,
            model.FilterSettings.AllowMultipleValues,
            model.FilterSettings.SearchKind,
            model.FilterSettings.Order?.Value);
        var registrySettings = new RegistrySettingsInternal(model.RegistrySettings.ShowInRegistry, model.RegistrySettings.ShowByDefault);
        List<AllowedAttributeConditionInternal> additionAllowedAttributesConditions = model.AdditionAllowedAttributesConditions.Select(ToInternal).ToList();

        var role = new DomainRegistryRoleInternal(
            model.Id.Value,
            model.DisplayName.Value,
            model.Name.Value,
            roleType,
            model.Kind,
            model.SystemName?.Value,
            registrySettings,
            filterSettings,
            additionAllowedAttributesConditions);

        return role;
    }

    public static AllowedAttributeConditionInternal ToInternal(AllowedAttributeCondition model) => model switch
    {
        ReferenceAllowedAttributeCondition r => new ReferenceAllowedAttributeConditionInternal(r.Value),
        StringAllowedAttributeCondition => new StringAllowedAttributeConditionInternal(),
        DateAllowedAttributeCondition => new DateAllowedAttributeConditionInternal(),
        NumberAllowedAttributeCondition => new NumberAllowedAttributeConditionInternal(),
        AttachmentAllowedAttributeCondition => new AttachmentAllowedAttributeConditionInternal(),
        BooleanAllowedAttributeCondition => new BooleanAllowedAttributeConditionInternal(),
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };
}
