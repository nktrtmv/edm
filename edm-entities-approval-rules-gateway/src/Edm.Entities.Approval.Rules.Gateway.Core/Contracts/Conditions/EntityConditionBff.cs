using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.AttributeValue;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Nary;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.None;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Unary;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;

[JsonDerivedType(typeof(EntityLogicalNaryConditionBff), "Nary")]
[JsonDerivedType(typeof(EntityAttributeValueConditionBff), "AttributeValue")]
[JsonDerivedType(typeof(EntityLogicalUnaryConditionBff), "Unary")]
[JsonDerivedType(typeof(EntityNoneConditionBff), "None")]
public abstract class EntityConditionBff
{
}
