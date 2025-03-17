using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.ReferenceAttributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.SetCurrentUserToAttributes;

internal sealed class SetCurrentUserToAttributeDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    DocumentAttributeValue? IDocumentAttributeValueFactory.CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentStatusTransition initialTransition = context.Template.DocumentPrototype.StatusTransitions.FirstOrDefault(s => s.From.Type == DocumentStatusType.Initial)
            ?? throw new BusinessLogicApplicationException("Не найден начальный статус");

        Id<DocumentAttribute>? setCurrentUserToAttributeId =
            ReferenceAttributeStatusParameterDetector.GetValueOrNull(initialTransition.From, DocumentStatusParameterKind.SetCurrentUserToAttribute);

        if (setCurrentUserToAttributeId is null)
        {
            return null;
        }

        DocumentReferenceAttribute? setCurrentUserToAttribute = AsSuitableAttribute(attribute, setCurrentUserToAttributeId);

        if (setCurrentUserToAttribute is null)
        {
            return null;
        }

        var currentUserId = IdConverterTo.ToString(context.CurrentUserId);

        DocumentAttributeValue result = Create(setCurrentUserToAttribute, currentUserId);

        return result;
    }

    private static DocumentReferenceAttribute? AsSuitableAttribute(DocumentAttribute attribute, Id<DocumentAttribute> setCurrentUserToAttributeId)
    {
        if (attribute is not DocumentReferenceAttribute result)
        {
            return null;
        }

        if (result.Id != setCurrentUserToAttributeId)
        {
            return null;
        }

        return result;
    }

    private static DocumentAttributeValue Create(DocumentReferenceAttribute attribute, string currentUserId)
    {
        var result = new ReferenceDocumentAttributeValue(attribute, [currentUserId]);

        return result;
    }
}
