using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators;

public static class DocumentValidatorByValidators
{
    public static DocumentValidatorValidationResult[] GetValidationResults(DocumentValidateParameters parameters)
    {
        DocumentValidator[] validators = DetectValidators(parameters.Document);

        DocumentAttributeValue[] planeAttributesValues = MakeTupleAttributesValuesPlane(parameters.AttributesValues);

        DocumentStatus? changedDocumentStatus = parameters.Document.StatusStateMachine.GetRequiredStatusById(parameters.ChangedStatusId);

        DocumentValidatorValidationResult[] validatorsResults = validators
            .Select(p => p.Validate(planeAttributesValues, changedDocumentStatus))
            .ToArray();

        return validatorsResults;
    }

    private static DocumentValidator[] DetectValidators(Document document)
    {
        bool validationShallBeSkipped = IsValidationShallBeSkipped(document);

        DocumentValidator[] result = validationShallBeSkipped
            ? Array.Empty<DocumentValidator>()
            : document.Validators;

        return result;
    }

    private static bool IsValidationShallBeSkipped(Document document)
    {
        if (document.Status.Type == DocumentStatusType.Approval)
        {
            return true;
        }

        if (document.Status.Type != DocumentStatusType.Signing)
        {
            return false;
        }

        DocumentSigningWorkflow? signing = document.SigningData.Workflows.Last();

        if (signing.IsSelfSigned)
        {
            return false;
        }

        return true;
    }

    private static DocumentAttributeValue[] MakeTupleAttributesValuesPlane(DocumentAttributeValue[] attributesValues)
    {
        var values = new List<DocumentAttributeValue>();

        foreach (DocumentAttributeValue? attributeValue in attributesValues)
        {
            if (attributeValue is TupleDocumentAttributeValue tupleAttributeValue)
            {
                DocumentAttributeValue[] innerTupleValues =
                    tupleAttributeValue.Values.Select(v => v.InnerValues).SelectMany(MakeTupleAttributesValuesPlane).ToArray();

                values.AddRange(innerTupleValues);
            }
            else
            {
                values.Add(attributeValue);
            }
        }

        return values.ToArray();
    }
}
