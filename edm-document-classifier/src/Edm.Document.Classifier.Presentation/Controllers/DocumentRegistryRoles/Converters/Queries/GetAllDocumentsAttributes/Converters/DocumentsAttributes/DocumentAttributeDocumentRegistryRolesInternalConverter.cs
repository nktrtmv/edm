using Edm.Document.Classifier.Application;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes.Types;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes;

internal static class DocumentAttributeDocumentRegistryRolesInternalConverter
{
    internal static DocumentAttributeDocumentRegistryRolesDto[] ToDto(DomainRegistryRoleInternal[] registryRoles, bool groupByConditions)
    {
        if (groupByConditions)
        {
            DocumentAttributeDocumentRegistryRolesDto[] groupedResult = ToGroupedByConditionsResult(registryRoles);

            return groupedResult;
        }

        DocumentAttributeDocumentRegistryRolesDto[] ungroupedResult = registryRoles.Select(ToUngroupedDto).ToArray();

        return ungroupedResult;
    }

    private static DocumentAttributeDocumentRegistryRolesDto[] ToGroupedByConditionsResult(DomainRegistryRoleInternal[] registryRoles)
    {
        DocumentAttributeDocumentRegistryRolesDto[] result = registryRoles
            .SelectMany(ToModelWithCondition)
            .GroupBy(x => x.condition)
            .Select(x => ToDto(x.Key, x.Select(y => y.model).ToList()))
            .ToArray();

        return result;
    }

    private static DocumentAttributeDocumentRegistryRolesDto ToUngroupedDto(DomainRegistryRoleInternal model)
    {
        DocumentAttributeTypeDto type = DocumentAttributeTypeInternalToDtoConverter.ToTypeDto(model);
        DocumentRegistryRoleDto role = DocumentRegistryRoleInternalConverter.ToDto(model);

        var result = new DocumentAttributeDocumentRegistryRolesDto
        {
            Attribute = type,
            Roles = { role }
        };

        return result;
    }

    private static DocumentAttributeDocumentRegistryRolesDto ToDto(
        AllowedAttributeConditionInternal condition,
        List<DomainRegistryRoleInternal> values)
    {
        DocumentAttributeTypeDto attributeType = ToAttributeType(condition);

        List<DocumentRegistryRoleDto> roles = values.Select(DocumentRegistryRoleInternalConverter.ToDto).ToList();
        var result = new DocumentAttributeDocumentRegistryRolesDto
        {
            Attribute = attributeType,
            Roles = { roles }
        };

        return result;
    }

    public static DocumentAttributeTypeDto ToAttributeType(AllowedAttributeConditionInternal model) => model switch
    {
        BooleanAllowedAttributeConditionInternal => new DocumentAttributeTypeDto { AsBoolean = new BooleanDocumentAttributeTypeDto() },
        DateAllowedAttributeConditionInternal => new DocumentAttributeTypeDto { AsDate = new DateDocumentAttributeTypeDto() },
        NumberAllowedAttributeConditionInternal => new DocumentAttributeTypeDto { AsNumber = new NumberDocumentAttributeTypeDto() },
        StringAllowedAttributeConditionInternal => new DocumentAttributeTypeDto { AsString = new StringDocumentAttributeTypeDto() },
        AttachmentAllowedAttributeConditionInternal => new DocumentAttributeTypeDto { AsAttachment = new AttachmentDocumentAttributeTypeDto() },
        ReferenceAllowedAttributeConditionInternal r => new DocumentAttributeTypeDto
        {
            AsReference = new ReferenceDocumentAttributeTypeDto { ReferenceTypeId = ReferenceIdToMetadataConverter.ToMetadata(r.ReferenceId) }
        },
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };

    private static IEnumerable<(AllowedAttributeConditionInternal condition, DomainRegistryRoleInternal model)> ToModelWithCondition(DomainRegistryRoleInternal model)
    {
        AllowedAttributeConditionInternal condition = ToCondition(model.Type);

        yield return (condition, model);

        foreach (AllowedAttributeConditionInternal additional in model.AdditionAllowedAttributesConditions)
        {
            yield return (additional, model);
        }
    }

    private static AllowedAttributeConditionInternal ToCondition(DocumentRegistryRoleTypeInternal model) => model switch
    {
        BooleanDocumentRegistryRoleTypeInternal => new BooleanAllowedAttributeConditionInternal(),
        DateDocumentRegistryRoleTypeInternal => new DateAllowedAttributeConditionInternal(),
        NumberDocumentRegistryRoleTypeInternal => new NumberAllowedAttributeConditionInternal(),
        StringDocumentRegistryRoleTypeInternal => new StringAllowedAttributeConditionInternal(),
        ReferenceDocumentRegistryRoleTypeInternal r => new ReferenceAllowedAttributeConditionInternal(r.ReferenceId),
        AttachmentDocumentRegistryRoleTypeInternal => new AttachmentAllowedAttributeConditionInternal(),
        _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
    };
}
