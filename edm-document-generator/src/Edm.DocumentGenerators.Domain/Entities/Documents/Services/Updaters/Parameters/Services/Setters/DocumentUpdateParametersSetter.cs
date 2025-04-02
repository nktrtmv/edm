using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Setters;

internal static class DocumentUpdateParametersSetter
{
    internal static void Set(DocumentUpdateParameters parameters, Document document)
    {
        if (parameters.AttributesChange is not null)
        {
            HashSet<Id<DocumentAttribute>>? existingAttributes = document.AttributesValues.Select(x => x.Id).ToHashSet();
            List<DocumentAttributeValue> nonExistingAttributes = document.AttributesValues.Where(x => !existingAttributes.Contains(x.Id)).ToList();

            if (nonExistingAttributes.Count > 0)
            {
                string? ids = string.Join(", ", nonExistingAttributes.Select(x => x.Id));

                throw new ApplicationException($"Attributes with ids {ids} weren't found in document");
            }

            List<DocumentAttributeValue> resultAttributes = parameters.AttributesChange.UpdatedValues.ToList();
            HashSet<Id<DocumentAttribute>> updatedIds = resultAttributes.Select(x => x.Id).ToHashSet();

            resultAttributes.AddRange(document.AttributesValues.Where(documentAttributesValue => !updatedIds.Contains(documentAttributesValue.Id)));

            document.SetAttributesValues(resultAttributes.ToArray());
        }

        if (parameters.StatusChange is not null)
        {
            document.SetStatus(parameters.StatusChange.Transition.To);
        }

        DocumentErrors? documentErrors = DetectDocumentErrors(parameters, document);

        document.SetErrors(documentErrors);
    }

    private static DocumentErrors DetectDocumentErrors(DocumentUpdateParameters parameters, Document document)
    {
        string[]? errors = DetectErrors(parameters, document);

        DocumentAttributeError[] attributesErrors = DetectAttributesErrors(parameters, document);

        DocumentErrors? result = DocumentErrorsFactory.CreateFrom(errors, attributesErrors);

        return result;
    }

    private static DocumentAttributeError[] DetectAttributesErrors(DocumentUpdateParameters parameters, Document document)
    {
        if (parameters.AttributesErrors is not null)
        {
            return parameters.AttributesErrors;
        }

        DocumentAttributeError[]? errors = document.DocumentErrors.AttributesErrors;

        if (errors.Length == 0 || parameters.AttributesChange == null)
        {
            return errors;
        }

        Dictionary<Id<DocumentAttribute>, DocumentAttributeValue> originalValuesById =
            parameters.AttributesChange.OriginalValues.ToDictionary(v => v.Id);

        Dictionary<Id<DocumentAttribute>, DocumentAttributeValue> updatedValuesById =
            parameters.AttributesChange.UpdatedValues.ToDictionary(v => v.Id);

        DocumentAttributeError[] result = errors
            .Where(e => HasNotBeenChanged(e, originalValuesById, updatedValuesById))
            .ToArray();

        return result;
    }

    private static string[] DetectErrors(DocumentUpdateParameters parameters, Document document)
    {
        string[]? result = parameters.CommonErrors ?? document.DocumentErrors.Errors;

        return result;
    }

    private static bool HasNotBeenChanged(
        DocumentAttributeError error,
        Dictionary<Id<DocumentAttribute>, DocumentAttributeValue> originalValuesById,
        Dictionary<Id<DocumentAttribute>, DocumentAttributeValue> updatedValuesById)
    {
        DocumentAttributeValue? originalValue = originalValuesById.GetValueOrDefault(error.AttributeId);

        DocumentAttributeValue? updatedValue = updatedValuesById.GetValueOrDefault(error.AttributeId);

        bool result = originalValue == updatedValue;

        return result;
    }
}
