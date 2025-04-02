using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Validators;

internal static class CreateByClassificationBusinessLogicValidator
{
    internal static void Validate(
        DocumentClassification classification,
        Id<DocumentTemplate>[] readyForDocumentCreationTemplatesIds)
    {
        if (readyForDocumentCreationTemplatesIds.Length == 1)
        {
            return;
        }

        BusinessLogicApplicationException? exception = readyForDocumentCreationTemplatesIds.Length == 0
            ? CreateNoTemplatesAreFound(classification)
            : CreateTooManyTemplatesAreFound(classification, readyForDocumentCreationTemplatesIds);

        throw exception;
    }

    private static BusinessLogicApplicationException CreateNoTemplatesAreFound(DocumentClassification classification)
    {
        var result = new BusinessLogicApplicationException(
            $"""
             No templates for classification is found.
             Classification: {classification}
             """);

        return result;
    }

    private static BusinessLogicApplicationException CreateTooManyTemplatesAreFound(
        DocumentClassification classification,
        Id<DocumentTemplate>[] readyForDocumentCreationTemplatesIds)
    {
        string? matchingTemplatesIds = string.Join<Id<DocumentTemplate>>(", ", readyForDocumentCreationTemplatesIds);

        var result = new BusinessLogicApplicationException(
            $"""
             Classification has {readyForDocumentCreationTemplatesIds.Length} matching templates, though only 1 is required.
             MatchingTemplatesIds: {matchingTemplatesIds}
             Classification: {classification}
             """);

        return result;
    }
}
