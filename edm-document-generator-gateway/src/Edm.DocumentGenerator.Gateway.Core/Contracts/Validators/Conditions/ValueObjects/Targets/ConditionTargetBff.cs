using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.ConditionTargetConstantValue;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets;

[DiscriminatorType<ConditionTargetBffType>]
[JsonDerivedType(typeof(ConditionTargetDocumentAttributeBff), nameof(ConditionTargetBffType.DocumentAttribute))]
[JsonDerivedType(typeof(ConditionTargetConstantValueNumberBff), nameof(ConditionTargetBffType.Number))]
[JsonDerivedType(typeof(ConditionTargetConstantValueBooleanBff), nameof(ConditionTargetBffType.Boolean))]
[JsonDerivedType(typeof(ConditionTargetConstantValueDateTimeBff), nameof(ConditionTargetBffType.DateTime))]
[JsonDerivedType(typeof(ConditionTargetConstantValueStringBff), nameof(ConditionTargetBffType.String))]
[JsonDerivedType(typeof(ConditionTargetConstantValueReferenceBff), nameof(ConditionTargetBffType.Reference))]
public abstract class ConditionTargetBff
{
}
