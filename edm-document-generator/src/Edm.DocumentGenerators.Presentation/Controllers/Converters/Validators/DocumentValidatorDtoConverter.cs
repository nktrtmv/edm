using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

public static class DocumentValidatorDtoConverter
{
    public static DocumentValidatorInternal ToInternal(DocumentValidatorDto validator)
    {
        Id<DocumentValidatorInternal> id = IdConverterFrom<DocumentValidatorInternal>.FromString(validator.Id);
        ConditionBaseInternal[] conditions = validator.Conditions.Select(ConditionDtoConverter.ToInternal).ToArray();

        var result = new DocumentValidatorInternal(id, conditions, validator.Name);

        return result;
    }

    public static DocumentValidatorDto FromInternal(DocumentValidatorInternal validator)
    {
        IEnumerable<OneOfConditionDto> conditions = validator.Conditions.Select(ConditionDtoConverter.FromInternal);

        var result = new DocumentValidatorDto
        {
            Id = IdConverterTo.ToString(validator.Id),
            Conditions = { conditions },
            Name = validator.Name
        };

        return result;
    }
}
