using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.Transitions.
    Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.
    Transitions;

internal static class DocumentTransitionTemplateParametersFactory
{
    private static readonly SendNotificationDocumentNotifierRequestNotificationParameter[] Empty =
        Array.Empty<SendNotificationDocumentNotifierRequestNotificationParameter>();

    internal static SendNotificationDocumentNotifierRequestNotificationParameter[] CreateFrom<TEventArgs>(TEventArgs eventArgs)
        where TEventArgs : notnull
    {
        SendNotificationDocumentNotifierRequestNotificationParameter[] result = eventArgs switch
        {
            DocumentStatusChangedEventArgs e => CreateParameters(e),
            DocumentAttributeValueChangedEventArgs => Empty,
            _ => throw new ArgumentTypeOutOfRangeException(eventArgs)
        };

        return result;
    }

    private static SendNotificationDocumentNotifierRequestNotificationParameter[] CreateParameters(DocumentStatusChangedEventArgs statusChangedEventArgs)
    {
        DocumentStatusTransitionParameterValue[] parameters = statusChangedEventArgs.Change.StatusTransitionParametersValues;

        if (!parameters.Any())
        {
            return Empty;
        }

        SendNotificationDocumentNotifierRequestNotificationParameter[] result = parameters
            .Select(CreateParameter)
            .ToArray();

        return result;
    }

    private static SendNotificationDocumentNotifierRequestNotificationParameter CreateParameter(DocumentStatusTransitionParameterValue parameterValue)
    {
        SendNotificationDocumentNotifierRequestNotificationParameter result = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValue p =>
                DocumentCommentTransitionTemplateParametersFactory.CreateFrom(p.Comment),

            DocumentCommentWithAttachmentsStatusTransitionParameterValue p =>
                DocumentCommentTransitionTemplateParametersFactory.CreateFrom(p.Comment),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }
}
