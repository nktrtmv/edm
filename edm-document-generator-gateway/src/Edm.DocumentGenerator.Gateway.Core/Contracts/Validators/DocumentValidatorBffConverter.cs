using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;

internal static class DocumentValidatorBffConverter
{
    internal static DocumentValidatorBff FromBff(DocumentValidatorDto documentValidator)
    {
        ConditionBaseBff[] conditions = documentValidator.Conditions.Select(ConditionBaseBffConverter.ToBff).ToArray();

        var validator = new DocumentValidatorBff(documentValidator.Id, conditions, documentValidator.Name);

        return validator;
    }

    internal static DocumentValidatorDto ToDto(DocumentValidatorBff documentValidator)
    {
        OneOfConditionDto[] conditions = documentValidator.Conditions.Select(ConditionBaseBffConverter.FromBff).ToArray();

        var validator = new DocumentValidatorDto
        {
            Id = documentValidator.Id,
            Conditions = { conditions },
            Name = documentValidator.Name
        };

        return validator;
    }
}
