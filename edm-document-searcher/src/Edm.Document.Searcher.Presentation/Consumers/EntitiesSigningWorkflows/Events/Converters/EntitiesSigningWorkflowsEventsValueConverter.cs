using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters.ContractorSigned;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters;

internal static class EntitiesSigningWorkflowsEventsValueConverter
{
    internal static IRequest ToInternal(EntitiesSigningWorkflowsEventsValue value)
    {
        var documentId = IdConverterFrom<SearchDocumentInternal>.FromString(value.EntityId);

        IRequest result = value.EventCase switch
        {
            EntitiesSigningWorkflowsEventsValue.EventOneofCase.ContractorSigned =>
                ContractorSignedEntitiesSigningWorkflowsEventConverter.ToInternal(documentId, value.DomainId),

            _ => throw new ArgumentTypeOutOfRangeException(value.EventCase)
        };

        return result;
    }
}
