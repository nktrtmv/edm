using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.String;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues;

[JsonDerivedType(typeof(EntityBooleanAttributeValueBff), "Boolean")]
[JsonDerivedType(typeof(EntityDateAttributeValueBff), "Date")]
[JsonDerivedType(typeof(EntityReferenceAttributeValueBff), "Reference")]
[JsonDerivedType(typeof(EntityNumberAttributeValueBff), "Number")]
[JsonDerivedType(typeof(EntityStringAttributeValueBff), "String")]
public abstract class EntityAttributeValueBff
{
    public required int Id { get; init; }
    public string? DisplayName { get; set; }
}
