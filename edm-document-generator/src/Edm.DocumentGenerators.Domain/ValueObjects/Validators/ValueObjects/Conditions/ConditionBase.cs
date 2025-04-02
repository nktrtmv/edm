using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;

public abstract class ConditionBase : ICondition
{
    protected ConditionBase(ConditionData data)
    {
        Data = data;
    }

    protected abstract ConditionAttributesRequirements Requirements { get; }

    protected Id<ICondition> Id => Data.ConditionId;
    public ConditionData Data { get; }

    public ConditionResult Check(DocumentAttributeValue[] documentAttributesValues, DocumentStatus changedDocumentStatus)
    {
        if (changedDocumentStatus.Type == DocumentStatusType.Cancelled)
        {
            return ConditionResult.Succeed(Data.ConditionId);
        }

        ValidateLinkedAttributesCount(documentAttributesValues);

        if (!ShouldProcessStatus(changedDocumentStatus))
        {
            return ConditionResult.Succeed(Data.ConditionId);
        }

        return OnCheck(documentAttributesValues);
    }

    private bool ShouldProcessStatus(DocumentStatus changedDocumentStatus)
    {
        if (Data.SupportedDocumentStatusIds.Length == 0 && changedDocumentStatus.Type != DocumentStatusType.Initial)
        {
            return true;
        }

        bool containsChangedStatus = Data.SupportedDocumentStatusIds.Contains(changedDocumentStatus.Id);

        if (containsChangedStatus)
        {
            return true;
        }

        return false;
    }

    protected abstract ConditionResult OnCheck(DocumentAttributeValue[] attributesValues);

    protected DocumentAttributeValue[] GetLinkedAttributesValues(DocumentAttributeValue[] documentAttributesValues)
    {
        DocumentAttributeValue[] linkedAttributesValues = documentAttributesValues
            .Where(p => Data.LinkedDocumentAttributeIds.Contains(p.Attribute.Id))
            .ToArray();

        return linkedAttributesValues;
    }

    protected DocumentAttributeValueGeneric<T>[] GetLinkedAttributesValuesGeneric<T>(DocumentAttributeValue[] documentAttributesValues)
    {
        DocumentAttributeValueGeneric<T>[] linkedAttributesValues = documentAttributesValues
            .Where(p => Data.LinkedDocumentAttributeIds.Contains(p.Attribute.Id))
            .Cast<DocumentAttributeValueGeneric<T>>()
            .ToArray();

        return linkedAttributesValues;
    }

    private void ValidateLinkedAttributesCount(DocumentAttributeValue[] documentAttributesValues)
    {
        int linkedAttributesValuesCount = documentAttributesValues
            .Count(p => Data.LinkedDocumentAttributeIds.Contains(p.Attribute.Id));

        if (Data.LinkedDocumentAttributeIds.Length != linkedAttributesValuesCount)
        {
            throw new BusinessLogicApplicationException(
                $"Condition {Data.ConditionId}: Linked documentAttributesValues count not equals to {nameof(Data.LinkedDocumentAttributeIds)}.Length .");
        }
    }

    protected static bool ValueIsEmptyOrDefault(DocumentAttributeValue attributeValue)
    {
        bool checkResult = attributeValue switch
        {
            DocumentAttributeValueGeneric<string> value =>
                DefaultGenericAttributeValueCheck(value) ||
                value.Values.All(string.IsNullOrEmpty),
            DocumentAttributeValueGeneric<UtcDateTime<DateDocumentAttributeValue>> value =>
                DefaultGenericAttributeValueCheck(value) ||
                value.Values.All(p => p == default),
            DocumentAttributeValueGeneric<Number<NumberDocumentAttributeValue>> value =>
                DefaultGenericAttributeValueCheck(value) ||
                value.Values.All(p => p == default),
            DocumentAttributeValueGeneric<bool> value =>
                DefaultGenericAttributeValueCheck(value) ||
                value.Values.All(p => p == default),
            TupleDocumentAttributeValue value =>

                //todo: check `All()` on business side.
                value.Values.All(TupleInnerValuesAreEmptyOrDefault),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return checkResult;
    }

    private static bool TupleInnerValuesAreEmptyOrDefault(TupleInnerValueDocumentAttributeValue value)
    {
        bool result = value.InnerValues.All(ValueIsEmptyOrDefault);

        return result;
    }

    private static bool DefaultGenericAttributeValueCheck<T>(DocumentAttributeValueGeneric<T> value)
    {
        return value.Values.Length == 0;
    }
}
