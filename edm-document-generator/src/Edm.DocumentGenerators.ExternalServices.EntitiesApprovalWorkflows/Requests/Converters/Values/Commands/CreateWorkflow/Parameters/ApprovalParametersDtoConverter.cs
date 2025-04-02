using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Infos;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Options;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters;

internal static class ApprovalParametersDtoConverter
{
    internal static ApprovalParametersDto FromDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestExternal request)
    {
        ApprovalEntityDto entity = ApprovalEntityDtoConverter.FromDomain(request.Document);

        ApprovalInfoDto info = ApprovalInfoDtoConverter.FromDomain(request.Parameters);

        ApprovalOptionsDto options = ApprovalOptionsDtoConverter.FromDomain(request.Options);

        var result = new ApprovalParametersDto
        {
            Entity = entity,
            Info = info,
            Options = options
        };

        return result;
    }
}
