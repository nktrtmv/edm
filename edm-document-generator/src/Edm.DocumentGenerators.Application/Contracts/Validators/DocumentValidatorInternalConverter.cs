using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators;

internal static class DocumentValidatorInternalConverter
{
    internal static DocumentValidatorInternal FromDomain(DocumentValidator documentValidator)
    {
        Id<DocumentValidatorInternal> id = IdConverterFrom<DocumentValidatorInternal>.From(documentValidator.Id);
        ConditionBaseInternal[] conditions = documentValidator.Conditions.Select(ConditionBaseInternalConverter.FromDomain).ToArray();

        var result = new DocumentValidatorInternal(id, conditions, documentValidator.Name);

        return result;
    }

    internal static DocumentValidator ToDomain(DocumentValidatorInternal documentValidatorInternal)
    {
        Id<DocumentValidator> id = IdConverterFrom<DocumentValidator>.From(documentValidatorInternal.Id);

        ICondition[] conditions = documentValidatorInternal.Conditions.Select(ConditionBaseInternalConverter.ToDomain).ToArray();

        var result = new DocumentValidator(id, conditions, documentValidatorInternal.Name);

        return result;
    }
}
