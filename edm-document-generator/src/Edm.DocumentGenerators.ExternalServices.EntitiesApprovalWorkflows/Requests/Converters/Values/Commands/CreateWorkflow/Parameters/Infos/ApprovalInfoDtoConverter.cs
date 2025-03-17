using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Infos;

internal static class ApprovalInfoDtoConverter
{
    internal static ApprovalInfoDto FromDomain(DocumentApprovalParameters parameters)
    {
        var clerkId = IdConverterTo.ToString(parameters.ClerkId);

        var documentAuthorId = IdConverterTo.ToString(parameters.DocumentAuthorId);

        string[] ownersIds = { clerkId };

        var result = new ApprovalInfoDto
        {
            Title = parameters.Title,
            Description = parameters.Description,
            OwnersIds = { ownersIds },
            DocumentAuthorId = documentAuthorId
        };

        return result;
    }
}
