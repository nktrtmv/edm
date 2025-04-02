using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters.SelfSigned;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters;

internal static class EntitiesSigningWorkflowsEventsValueConverter
{
    internal static IRequest ToInternal(EntitiesSigningWorkflowsEventsValue value)
    {
        Id<DocumentInternal>? documentId =
            IdConverterFrom<DocumentInternal>.FromString(value.EntityId);

        Id<DocumentSigningWorkflowInternal> workflowId =
            IdConverterFrom<DocumentSigningWorkflowInternal>.FromString(value.SigningId);

        IRequest result = value.EventCase switch
        {
            EntitiesSigningWorkflowsEventsValue.EventOneofCase.SelfSigned =>
                SelfSignedEntitiesSigningWorkflowsEventConverter.ToInternal(documentId, workflowId),

            _ => throw new ArgumentTypeOutOfRangeException(value.EventCase)
        };

        return result;
    }
}
