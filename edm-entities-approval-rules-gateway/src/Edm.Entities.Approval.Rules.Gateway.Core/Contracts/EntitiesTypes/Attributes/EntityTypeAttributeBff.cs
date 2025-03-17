using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.String;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes;

[JsonDerivedType(typeof(EntityTypeBooleanAttributeBff), "Boolean")]
[JsonDerivedType(typeof(EntityTypeDateAttributeBff), "Date")]
[JsonDerivedType(typeof(EntityTypeNumberAttributeBff), "Number")]
[JsonDerivedType(typeof(EntityTypeReferenceAttributeBff), "Reference")]
[JsonDerivedType(typeof(EntityTypeStringAttributeBff), "String")]
public abstract class EntityTypeAttributeBff
{
    public required EntityTypeAttributeDataBff Data { get; init; }
}
