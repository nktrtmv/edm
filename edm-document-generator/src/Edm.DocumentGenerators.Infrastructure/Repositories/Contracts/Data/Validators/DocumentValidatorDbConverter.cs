using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators.Conditions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators;

internal static class DocumentValidatorDbConverter
{
    internal static DocumentValidator ToDomain(DocumentValidatorDb documentValidatorDb)
    {
        ICondition[] conditions = documentValidatorDb.Conditions.Select(ConditionDbConverter.ToDomain).ToArray();
        Id<DocumentValidator> id = IdConverterFrom<DocumentValidator>.FromString(documentValidatorDb.Id);

        var documentValidator = new DocumentValidator(id, conditions, documentValidatorDb.Name);

        return documentValidator;
    }

    internal static DocumentValidatorDb FromDomain(DocumentValidator validator)
    {
        var documentValidatorDb = new DocumentValidatorDb
        {
            Id = IdConverterTo.ToString(validator.Id),
            Conditions = { validator.Conditions.Select(ConditionDbConverter.FromDomain).ToArray() },
            Name = validator.Name
        };

        return documentValidatorDb;
    }
}
