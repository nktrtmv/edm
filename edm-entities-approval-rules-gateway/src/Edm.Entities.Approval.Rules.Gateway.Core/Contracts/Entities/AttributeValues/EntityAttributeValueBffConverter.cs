using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.String;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues;

internal static class EntityAttributeValueBffConverter
{
    internal static EntityAttributeValueBff FromDto(EntityAttributeValueDto attributeValue, ApprovalEnrichersContext context)
    {
        var id = attributeValue.Id;

        EntityAttributeValueBff result = attributeValue.ValueCase switch
        {
            EntityAttributeValueDto.ValueOneofCase.AsBoolean =>
                EntityBooleanAttributeValueBffConverter.FromDto(attributeValue.AsBoolean, id),

            EntityAttributeValueDto.ValueOneofCase.AsDate =>
                EntityDateAttributeValueBffConverter.FromDto(attributeValue.AsDate, id),

            EntityAttributeValueDto.ValueOneofCase.AsNumber =>
                EntityNumberAttributeValueBffConverter.FromDto(attributeValue.AsNumber, id),

            EntityAttributeValueDto.ValueOneofCase.AsReference =>
                EntityReferenceAttributeValueBffConverter.FromDto(attributeValue.AsReference, id, context),

            EntityAttributeValueDto.ValueOneofCase.AsString =>
                EntityStringAttributeValueBffConverter.FromDto(attributeValue.AsString, id),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        var enricher = new EntityAttributeValueBffEnricherTarget(result);

        context.Add(enricher);

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityAttributeValueBff attributeValue)
    {
        var result = attributeValue switch
        {
            EntityBooleanAttributeValueBff a => EntityBooleanAttributeValueBffConverter.ToDto(a),
            EntityDateAttributeValueBff a => EntityDateAttributeValueBffConverter.ToDto(a),
            EntityNumberAttributeValueBff a => EntityNumberAttributeValueBffConverter.ToDto(a),
            EntityReferenceAttributeValueBff a => EntityReferenceAttributeValueBffConverter.ToDto(a),
            EntityStringAttributeValueBff a => EntityStringAttributeValueBffConverter.ToDto(a),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }
}
