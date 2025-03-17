using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;

internal static class DocumentAttributesHasCorrectDefaultValues
{
    internal static void Validate(DocumentAttribute[] attributes)
    {
        foreach (DocumentAttribute documentAttribute in attributes)
        {
            bool isValid = documentAttribute switch
            {
                DocumentBooleanAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentDateAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentAttachmentAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentNumberAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentReferenceAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentStringAttribute attribute => IsValidDefaultValuesCount(attribute.DefaultValues, attribute),
                DocumentTupleAttribute => true,
                _ => throw new ArgumentTypeOutOfRangeException(documentAttribute)
            };

            if (!isValid)
            {
                throw new BusinessLogicApplicationException(
                    $"""
                     Attribute has incorrect default values count.
                     AttributeId: {documentAttribute.Id}
                     """);
            }
        }
    }

    private static bool IsValidDefaultValuesCount<T>(T[] defaultValues, DocumentAttribute attribute)
    {
        if (defaultValues.Length == 0)
        {
            return true;
        }

        if (!attribute.IsArray && defaultValues.Length > 1)
        {
            return false;
        }

        return true;
    }
}
