using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.Types;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

[DiscriminatorType<ConditionBffType>]
[JsonDerivedType(typeof(ConditionEmptyBff), nameof(ConditionBffType.Empty))]
[JsonDerivedType(typeof(ConditionExistsBff), nameof(ConditionBffType.Exists))]
[JsonDerivedType(typeof(ConditionExistsAnyBff), nameof(ConditionBffType.ExistsAny))]
[JsonDerivedType(typeof(ConditionExistsWithReferencePreconditionBff), nameof(ConditionBffType.ExistsWithReferencePrecondition))]
[JsonDerivedType(typeof(ConditionRegexBff), nameof(ConditionBffType.Regex))]
[JsonDerivedType(typeof(ConditionSumEqualsBff), nameof(ConditionBffType.SumEquals))]
[JsonDerivedType(typeof(ConditionCompareBff), nameof(ConditionBffType.Compare))]
[JsonDerivedType(typeof(ConditionCompareReferenceBff), nameof(ConditionBffType.CompareReference))]
public abstract class ConditionBaseBff
{
    protected ConditionBaseBff(ConditionDataBff data)
    {
        Data = data;
    }

    public ConditionDataBff Data { get; }
}
