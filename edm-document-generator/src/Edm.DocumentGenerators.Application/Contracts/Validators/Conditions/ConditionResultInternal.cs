using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;

public sealed class ConditionResultInternal
{
    public required Id<ConditionBaseInternal> ConditionId { get; init; }

    public required Id<DocumentAttributeInternal>[] FailedAttributes { get; init; }

    public required Id<DocumentAttributeInternal>[] ShouldBeEmptyAttributesId { get; init; }
}
