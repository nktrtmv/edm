using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;

public interface ICondition
{
    ConditionData Data { get; }

    ConditionResult Check(DocumentAttributeValue[] documentAttributesValues, DocumentStatus changedDocumentStatus);
}
