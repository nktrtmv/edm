using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators;

public sealed class DocumentValidator
{
    public DocumentValidator(Id<DocumentValidator> id, ICondition[] conditions, string name)
    {
        Id = id;
        Conditions = conditions;
        Name = name;
    }

    public ICondition[] Conditions { get; }
    public Id<DocumentValidator> Id { get; }
    public string Name { get; }

    public DocumentValidatorValidationResult Validate(DocumentAttributeValue[] documentAttributesValues, DocumentStatus changedDocumentStatus)
    {
        ConditionResult[] conditionResults = Conditions
            .Select(p => p.Check(documentAttributesValues, changedDocumentStatus))
            .ToArray();

        return new DocumentValidatorValidationResult(Id, conditionResults);
    }
}
