using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Entities;

internal static class ApprovalEntityDtoConverter
{
    internal static ApprovalEntityDto FromDomain(Document document)
    {
        var id = IdConverterTo.ToString(document.Id);

        var result = new ApprovalEntityDto
        {
            Id = id,
            DomainId = document.DomainId.Value
        };

        return result;
    }
}
